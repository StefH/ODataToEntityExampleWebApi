﻿using Microsoft.AspNetCore.Mvc;
using OdataToEntity.AspNetCore;

namespace ODataToEntityExampleWebApi.Controllers
{
    public class MetadataController : OeMetadataController
    {
        [Route("$metadata")]
        public void GetCsdl()
        {
            base.GetCsdlSchema();
        }

        // TODO : not yet in NuGet ?
        //[Route("api/$json-schema")]
        //public void GetJson()
        //{
        //    base.GetJsonSchema();
        //}
    }
}