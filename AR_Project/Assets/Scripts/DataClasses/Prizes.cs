﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using AR_Project.DataClasses.NestedObjects;

namespace AR_Project.DataClasses
{
    [JsonObject]
    public class Prizes
    {
        [JsonProperty(PropertyName = "Premios")]
        public List<Prize> prizes;
    }
}
