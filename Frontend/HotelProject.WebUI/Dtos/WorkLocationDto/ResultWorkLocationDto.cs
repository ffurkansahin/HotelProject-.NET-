﻿using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.WorkLocationDto
{
    public class ResultWorkLocationDto
    {
        public int WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        public string? WorkLocationCityName { get; set; }
    }
}
