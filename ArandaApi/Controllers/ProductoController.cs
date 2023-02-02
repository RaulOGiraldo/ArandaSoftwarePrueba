using ArandaApi.Responses;
using Bisiness.CustomEntities;
using Bisiness.DTOs;
using Bisiness.interfaces;
using Bisiness.QueryFilters;
using Data.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ArandaApi.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly IProductoServices _productoService;
        public ProductoController(IProductoServices productoService)
        {
            //_productoService = new ProductoServices();
            _productoService = productoService;
        }

        // GET: api/Producto
        [HttpGet]
        public async Task<IHttpActionResult> GetAll([FromBody] ProductoQueryFilter filters, HttpRequestMessage Response)
        {
            var productos = await _productoService.GelAll(filters);
            var metadata = new Metadata
            {
                TotalCount = productos.TotalCount,
                PageSize = productos.PageSize,
                CurrentPage = productos.CurrentPage,
                TotalPages = productos.TotalPages,
                HasNextPage = productos.HasNextPage,
                HasPreviousPage = productos.HasPreviousPage
            };


            var response = new ApiResponse<IEnumerable<ProductoDTO>>(productos) { Meta = metadata };

            //JsonSerializerSettings options = new
            //{
            //    DefaultIgnoreCondition =  WhenWritingNull
            //};


            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        // GET: api/Producto/5
        public async Task<IHttpActionResult> Get(int Id)
        {
            var producto = await _productoService.Get(Id);
            if (producto == null) { return NotFound(); }

            var response = new ApiResponse<Producto>(producto);
            return Ok(response);
        }


        // POST: api/Producto
        [HttpPost]
        public async Task<IHttpActionResult> Post(Producto producto)
        {
            string menx = "Could not insert record";
            var respx = await _productoService.Insert(producto);
            if (respx) { menx = "The record was inserted correctly."; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        // PUT: api/Producto/5
        [HttpPut()]
        public async Task<IHttpActionResult> Put(int Id, Producto producto)
        {
            string menx = "Could not edit the record";
            var prodx = await _productoService.Get(Id);
            if (prodx == null) { return NotFound(); }

            producto.Id = Id;
            var respx = await _productoService.Update(Id, producto);
            if (respx) { menx = "The registry successfully edited"; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }

        // DELETE: api/Producto/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int Id)
        {
            string menx = "Could not delete record";
            var producto = await _productoService.Get(Id);
            if (producto == null) { return NotFound(); }

            var respx = await _productoService.Delete(Id);
            if (respx) { menx = "The record was successfully deleted"; }
            var response = new ApiResponse<string>(menx);
            return Ok(response);
        }
    }
}
