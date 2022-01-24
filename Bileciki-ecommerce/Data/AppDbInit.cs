using Bileciki_ecommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bileciki_ecommerce.Data
{
    public class AppDbInit
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //seeding
                //cinema
                if(!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    { 
                     new Cinema()
                     {
                         Name = "Helios",
                         Logo = "https://i.ibb.co/pv7vzw1/s4-kino-konesera-w-kinie-helios-1504170916-1.jpg",
                         Description = "This is cinema helios, and this text is a sample description."
                     },
                     new Cinema()
                     {
                         Name = "Multikino",
                         Logo = "https://i.ibb.co/9tBnDv6/Multikino66.png",
                         Description = "This is cinema mulitkino, and this text is a sample description."
                     },
                     new Cinema()
                     {
                         Name = "CinemaCity",
                         Logo = "https://i.ibb.co/t4yzf9y/cinemacity-logo.jpg",
                         Description = "This is cinema cinemacity, and this text is a sample description."
                     },
                     new Cinema()
                     {
                         Name = "Imax",
                         Logo = "https://i.ibb.co/KbGZXQX/IMAX-Logo.jpg",
                         Description = "This is cinema IMAX, and this text is a sample description."
                     }
                    });
                    context.SaveChanges();
                }
                //actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Fullname = "Actor 1 m",
                            Bio = "This actor is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/hBG15Qg/man.jpg"
                        },
                        new Actor()
                        {
                            Fullname = "Actor 2 f",
                            Bio = "This actor is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/tKHV787/woman.jpg"
                        },
                        new Actor()
                        {
                            Fullname = "Actor 3 m",
                            Bio = "This actor is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/hBG15Qg/man.jpg"
                        },
                        new Actor()
                        {
                            Fullname = "Actor 4 f",
                            Bio = "This actor is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/tKHV787/woman.jpg"
                        },
                        new Actor()
                        {
                            Fullname = "Actor 5 m",
                            Bio = "This actor is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/hBG15Qg/man.jpg"
                        },
                    });
                    context.SaveChanges();
                }
                //producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Fullname = "Producer 1 m",
                            Bio = "This producer is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/hBG15Qg/man.jpg"
                        },
                        new Producer()
                        {
                            Fullname = "Producer 2 f",
                            Bio = "This producer is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/tKHV787/woman.jpg"
                        },
                        new Producer()
                        {
                            Fullname = "Producer 3 m",
                            Bio = "This producer is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/hBG15Qg/man.jpg"
                        },
                        new Producer()
                        {
                            Fullname = "Producer 4 f",
                            Bio = "This producer is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/tKHV787/woman.jpg"
                        },
                        new Producer()
                        {
                            Fullname = "Producer 5 m",
                            Bio = "This producer is a famous person in show-biznes scene. And this text is a sample bio.",
                            ProfilePictureURL = "https://i.ibb.co/hBG15Qg/man.jpg"
                        },
                    });
                    context.SaveChanges();

                }
                //movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "KillBill",
                            Description = "Killbill movie desc",
                            Price = 14.99,
                            ImageURL = "https://i.ibb.co/bs26D1G/killbill.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Django",
                            Description = "Django movie desc",
                            Price = 16.99,
                            ImageURL = "https://i.ibb.co/qkbHmSQ/django.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Thriller
                        },
                        new Movie()
                        {
                            Name = "Hatefull 8",
                            Description = "Hatefull 8 movie desc",
                            Price = 13.99,
                            ImageURL = "https://i.ibb.co/vxbBmV3/hateful8.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Resevoir dogs",
                            Description = "Resevoir dogs movie desc",
                            Price = 12.99,
                            ImageURL = "https://i.ibb.co/1dgPZFC/reservoirdogs.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Comedy
                        },
                        new Movie()
                        {
                            Name = "Pulpfiction",
                            Description = "Pulpfiction movie desc",
                            Price = 17.99,
                            ImageURL = "https://i.ibb.co/QcNBL04/pulpfiction.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Thriller
                        }
                        ,new Movie()
                        {
                            Name = "Once upon a time in hollywood",
                            Description = "Once upon a time in hollywood movie desc",
                            Price = 16.99,
                            ImageURL = "https://i.ibb.co/G7myGLS/ouatih.jpg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 1,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Comedy
                        }
                    });
                    context.SaveChanges();

                }
                //actors_movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    { 
                        //movie #1
                        new Actor_Movie()
                        {
                            MovieId =1,
                            ActorId =1,
                        },
                        new Actor_Movie()
                        {
                            MovieId =1,
                            ActorId =2,
                        },new Actor_Movie()
                        {
                            MovieId =1,
                            ActorId =3,
                        },
                        //movie #2
                        new Actor_Movie()
                        {
                            MovieId =2,
                            ActorId =5,
                        },new Actor_Movie()
                        {
                            MovieId =2,
                            ActorId =3,
                        }
                        //movie #3
                        ,new Actor_Movie()
                        {
                            MovieId =3,
                            ActorId =4,
                        },
                        //movie #4
                        new Actor_Movie()
                        {
                            MovieId =4,
                            ActorId =1,
                        },new Actor_Movie()
                        {
                            MovieId =4,
                            ActorId =3,
                        },
                        //movie #5
                        new Actor_Movie()
                        {
                            MovieId =5,
                            ActorId =2,
                        },new Actor_Movie()
                        {
                            MovieId =5,
                            ActorId =4,
                        },new Actor_Movie()
                        {
                            MovieId =5,
                            ActorId =5,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
