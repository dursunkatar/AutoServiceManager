﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Dto
{
    public class TextValueDto<T>
    {
        public string Text { get; set; }
        public T Value { get; set; }
    }
}
