using AutoMapper;

using APICurso1500.Models;

namespace APICurso1500.Profiles
{
    public class ContactProfile:Profile
    {
        public ContactProfile()
        {

            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

        }
    }
}
