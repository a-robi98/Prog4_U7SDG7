using Microsoft.AspNetCore.Mvc;
using MyGuitarShop.Data;
using MyGuitarShop.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyGuitarShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GuitarController : ControllerBase
    {
        IManagementLogic managementLogic;
        IProcurementLogic procurementLogic;
        ISellerLogic sellerLogic;

        public GuitarController(IManagementLogic managementLogic, IProcurementLogic procurementLogic, ISellerLogic sellerLogic)
        {
            this.managementLogic = managementLogic;
            this.procurementLogic = procurementLogic;
            this.sellerLogic = sellerLogic;
        }

        // GET: api/<GuitarController>
        [HttpGet]
        public IEnumerable<Guitar> GetAllGuitars()
        {
            return this.sellerLogic.GetAllGuitars();
        }

        // GET api/<GuitarController>/5
        [HttpGet("{id}")]
        public Guitar GetGuitarById(int id)
        {
            return this.sellerLogic.GetGuitarById(id);
        }

        // POST api/<GuitarController>
        [HttpPost]
        public void InsertGuitar([FromBody] Guitar value)
        {
            this.procurementLogic.InsertGuitar(value);
        }

        // PUT api/<GuitarController>/5
        [HttpPut("{id}")]
        public void ChangeGuitarBrand(int id, [FromBody] Guitar value)
        {
            this.procurementLogic.ChangeGuitarBrand(id, value.Brand);
            this.procurementLogic.ChangeGuitarModell(id, value.Modell);
            this.procurementLogic.ChangeGuitarPrice(id, value.Price);
        }

        // DELETE api/<GuitarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var guitar = this.sellerLogic.GetGuitarById(id);
            this.managementLogic.RemoveFromGuitar(guitar);
        }
    }
}
