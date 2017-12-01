﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sledzto.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public int OptionId { get; set; }
        public MessageTypeEnum MessageType { get; set; }
        public virtual Option Option { get; set; }
    }
}