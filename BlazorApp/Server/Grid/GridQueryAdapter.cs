using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MaskShop.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Grid
{
    public class GridQueryAdapter
    {
        private readonly IFilters _controls;

        private readonly Dictionary<ProductFilterColumns, Expression<Func<Product, dynamic>>> _expressions
            = new Dictionary<ProductFilterColumns, Expression<Func<Product, dynamic>>>
            {
                { ProductFilterColumns.Id, c => c.Id },
                { ProductFilterColumns.Name, c => c.Name },
                { ProductFilterColumns.ProductCategoryId, c => c.ProductCategoryId },
                { ProductFilterColumns.From, c => c.ValidFrom },
                { ProductFilterColumns.To, c => c.ValidTo }
            };

        private readonly Dictionary<ProductFilterColumns, Func<IQueryable<Product>, IQueryable<Product>>> _filterQueries;

        public GridQueryAdapter(IFilters controls)
        {
            _controls = controls;

            _filterQueries = new Dictionary<ProductFilterColumns, Func<IQueryable<Product>, IQueryable<Product>>>
            {
                { ProductFilterColumns.Id, cs => cs.Where(c => c.Id.Contains(_controls.FilterText)) },
                { ProductFilterColumns.Name, cs => cs.Where(c => c.Name.Contains(_controls.FilterText)) },
                { ProductFilterColumns.ProductCategoryId, cs => cs.Where(c => c.ProductCategoryId.Contains(_controls.FilterText)) }
            };
        }

        public async Task<ICollection<Product>> FetchAsync(IQueryable<Product> query)
        {
            query = FilterAndQuery(query);
            await CountAsync(query);
            var collection = await FetchPageQuery(query)
                .ToListAsync();
            _controls.PageHelper.PageItems = collection.Count;
            return collection;
        }

        public async Task CountAsync(IQueryable<Product> query)
        {
            _controls.PageHelper.TotalItemCount = await query.CountAsync();
        }

        public IQueryable<Product> FetchPageQuery(IQueryable<Product> query)
        {
            return query
                .Skip(_controls.PageHelper.Skip)
                .Take(_controls.PageHelper.PageSize)
                .AsNoTracking();
        }

        private IQueryable<Product> FilterAndQuery(IQueryable<Product> root)
        {
            var sb = new System.Text.StringBuilder();

            if (!string.IsNullOrWhiteSpace(_controls.FilterText))
            {
                var filter = _filterQueries[_controls.FilterColumn];
                sb.Append($"Filter: '{_controls.FilterColumn}' ");
                root = filter(root);
            }

            var expression = _expressions[_controls.SortColumn];
            sb.Append($"Sort: '{_controls.SortColumn}' ");

            var sortDir = _controls.SortAscending ? "ASC" : "DESC";
            sb.Append(sortDir);

            Debug.WriteLine(sb.ToString());
            return _controls.SortAscending ? root.OrderBy(expression)
                : root.OrderByDescending(expression);
        }
    }
}
