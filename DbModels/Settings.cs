using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAppWithMongoDB.DbModels
{
    public class Settings
    {

        public string ConnectionString;
        public string Database;
        public IConfigurationRoot IConfigurationRoot;
    }
}
