using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ni
{
    public class GuestResponse
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required(ErrorMessage="you need choose this")]
        public bool? WillAttend { get; set; }
    }

    public class ResponseRepository
    {
        private static ResponseRepository repository = new ResponseRepository();
        private List<GuestResponse> responses = new List<GuestResponse>();
        public static ResponseRepository GetRepository()
        {
            return repository;
        }
        public IEnumerable<GuestResponse> GetAllResponses()
        {
            return responses;
        }

        public void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }


}