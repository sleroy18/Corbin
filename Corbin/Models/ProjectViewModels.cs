using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Corbin.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
    }

    public class ProjectCreateViewModel
    {
        [Required(ErrorMessage = "Please enter a {0}")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFile { get; set; }
        [Display(Name = "Video")]
        public HttpPostedFileBase VideoFile { get; set; }
    }

    //public class ProjectDetailsViewModel
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public DateTime LastUpdated { get; set; }
    //    public IEnumerable<Image> Images { get; set; }
    //    public IEnumerable<Video> Videos { get; set; }
    //}

    //public class ProjectEditViewModel
    //{
    //    public int Id { get; set; }
    //    [Required(ErrorMessage = "Please enter a {0}")]
    //    public string Title { get; set; }
    //    public string Description { get; set; }
    //    public IEnumerable<ImageViewModel> Images { get; set; }
    //    public IEnumerable<VideoViewModel> Videos { get; set; }
    //}

    //public class ProjectDeleteViewModel
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public byte[] imageStream { get; set; }
    //}

    //public class ImageViewModel
    //{
    //    public string Description { get; set; }
    //    public HttpPostedFileBase ImageFile { get; set; }
    //}

    //public class VideoViewModel
    //{
    //    public string Description { get; set; }
    //    public HttpPostedFileBase VideoFile { get; set; }
    //}
}