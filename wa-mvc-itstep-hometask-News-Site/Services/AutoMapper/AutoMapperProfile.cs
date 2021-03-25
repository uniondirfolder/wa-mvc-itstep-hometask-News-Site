using wa_mvc_itstep_hometask_News_Site.Models.Entities;
using wa_mvc_itstep_hometask_News_Site.Models.Helpers;
using wa_mvc_itstep_hometask_News_Site.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace wa_mvc_itstep_hometask_News_Site.Services.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OneNews, OneNewsVM>().ConstructUsing(n => new OneNewsVM()
            {
                Title = n.Title,
                Author = n.Author,
                Description = n.Description,
                Date = n.Date,
                Category = n.Category,
                ImageLink = n.ImageLink,
                Link = n.Url,
                HtmlElements = new List<HtmlElement>()
            });

            CreateMap<RegisterVM, User>().ConstructUsing(u => new User()
            {
                Email = u.Email,
                RegistrationDate = DateTime.Now,
                IsLocked = false
            });

            CreateMap<OneNews, SavedNews>().ConstructUsing(s => new SavedNews()
            {
                Title = s.Title,
                Link = s.Url,
                Author = s.Author,
                Category = s.Category,
                ImageLink = s.ImageLink,
                Description = s.Description,
                PublicationDate = s.Date
            });

            CreateMap<User, UserAdminVM>().ConstructUsing(u => new UserAdminVM()
            {
                Id = u.Id,
                Email = u.Email,
                IsLocked = u.IsLocked,
                RegistrationDate = u.RegistrationDate
            });
        }
    }
}
