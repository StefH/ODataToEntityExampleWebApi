﻿using Microsoft.AspNetCore.Mvc;
using OdataToEntity.AspNetCore;

namespace ODataToEntityExampleWebApi.Controllers
{
    public class MetadataController : OeMetadataController
    {
        [Route("$metadata")]
        public void GetCsdl()
        {
            GetCsdlSchema();
        }

        [Route("api/$json-schema")]
        public void GetJson()
        {
            GetJsonSchema();
        }
    }
}