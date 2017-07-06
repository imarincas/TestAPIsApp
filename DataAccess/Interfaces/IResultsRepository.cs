﻿using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IResultsRepository
    {
        List<TestsDTO> GetResults(UserDTO user);
        bool InsertTestcaseInDB(TestsDTO result);
    }
}
