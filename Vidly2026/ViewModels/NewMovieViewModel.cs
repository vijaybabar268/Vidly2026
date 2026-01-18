using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly2026.Models;

namespace Vidly2026.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get { return (Movie != null) ? "Edit" : "New"; }
        }
    }
}