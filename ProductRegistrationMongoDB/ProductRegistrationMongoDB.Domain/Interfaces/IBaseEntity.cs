﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistrationMongoDB.Domain.Interfaces
{
    public interface IBaseEntity
    {
        ObjectId Id { get; set; }
    }
}
