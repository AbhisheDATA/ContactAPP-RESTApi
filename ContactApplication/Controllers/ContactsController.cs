using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactApplication.Repository;
using ContactApplication.Model;
using ContactApplication.Entities;
using ContactApplication.ContractApp;
using Microsoft.AspNetCore.Authorization;

namespace ContactApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly Icontact contactRepository;
        public ContactsController(Icontact contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        [HttpPost, Route("AddContact")]
        public async Task<IActionResult> AddNewContact(Contact contact)
        {
            try
            {
                await contactRepository.AddContactAsync(contact);
                return StatusCode(201, "successfully added new product");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpGet,Route("GetContactById/{id}")]
        public async Task<IActionResult> GetcontactByid(int id)
        {
            try
            {
                Contact contact = await contactRepository.GetContactById(id);
                if (contact != null)
                {
                    return StatusCode(202, contact);
                }
                else
                {
                    return StatusCode(404, "contact not found");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetAllContact")]
        public async Task<IActionResult> GetAllcontact()
        {
            try
            {
                List<Contact> contacts = await contactRepository.GetAllContact();
                if (contacts != null)
                {
                    return StatusCode(202, contacts);
                }
                else
                {
                    return StatusCode(404, "contact not found");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetContactByName/{name}")]
        public async Task<IActionResult> GetcontactByid(string name)
        {
            try
            {
                List<Contact> contacts = await contactRepository.GetContactByName(name);
                if (contacts != null)
                {
                    return StatusCode(202, contacts);
                }
                else
                {
                    return StatusCode(404, "contact not found");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpPut, Route("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContactAsyn(int id, ContactModel contactModel)
        {
            try
            {
                await contactRepository.UpdateContactAsync(id, contactModel);
                return StatusCode(201, "successfully updated the contact");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        
        [HttpDelete, Route("DeleteContactById/{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
        {
            try
            {
                await contactRepository.DeleteContactAsync(id);

                return StatusCode(200, "Contact Details Deleted");
               
             

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

    }
}
