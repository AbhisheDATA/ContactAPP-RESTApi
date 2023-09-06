using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactApplication.ContractApp;
using ContactApplication.Model;
using ContactApplication.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ContactApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavouriteContactsController : ControllerBase
    {
        private readonly IfavouriteContact contactRepository;
        public FavouriteContactsController(IfavouriteContact contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        [HttpPost, Route("AddContact/{id}")]
        public async Task<IActionResult> AddNewFavouriteContact( int id)
        {
            try
            {
                await contactRepository.AddToFavouriteList(  id);
                return StatusCode(201, "successfully added favourite contact");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet, Route("GetFavouriteContactById/{id}")]
        public async Task<IActionResult> GetFvrtcontactByid(int id)
        {
            try
            {
                FavouriteContact contact = await contactRepository.GetFavrtContactById(id);
                if (contact != null)
                {
                    return StatusCode(202, contact);
                }
                else
                {
                    return StatusCode(404, "sorry There is no favourite contact found by this id");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetFavouriteAllContact")]
        public async Task<IActionResult> GetFavouriteAllcontact()
        {
            try
            {
                List<FavouriteContact> contacts = await contactRepository.GetAllFavouriteContact();
                if (contacts != null)
                {
                    return StatusCode(202, contacts);
                }
                else
                {
                    return StatusCode(404, "Favourite contact not found");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetFvrtContactByName/{name}")]
        public async Task<IActionResult> GetFvrtcontactByid(string name)
        {
            try
            {
                List<FavouriteContact> contacts = await contactRepository.GetFvrtContactByName(name);
                if (contacts != null)
                {
                    return StatusCode(202, contacts);
                }
                else
                {
                    return StatusCode(404, "Favourite contact not found");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteFavouriteContactById/{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            try
            {
                await contactRepository.DeleteFvrtContactAsync(id);

                return StatusCode(200, "Favourite Contact Details Deleted");



            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

