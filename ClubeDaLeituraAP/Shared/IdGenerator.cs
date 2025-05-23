﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.Shared
{
    public static class IdGenerator 
    {
        public static int BoxId = 0;
        public static int UserId = 0;
        public static int MagazineId = 0;
        public static int BorrowId;

        public static int GenerateBoxID()
        {
            BoxId++;
            return BoxId;
        }

        public static int GenerateUserID()
        {
            UserId++;
            return UserId;
        }

        public static int GenerateMagazine()
        {
            MagazineId++;
            return MagazineId;
        }

        public static int GenerateBorrowId()
        {
            BorrowId++;
            return BorrowId;
        }
    }
}
