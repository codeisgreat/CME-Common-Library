﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace MegaMan
{
    public class WeaponInfo
    {
        public FilePath IconOn { get; set; }
        public FilePath IconOff { get; set; }
        public string Name { get; set; }
        public string Entity { get; set; }
        public Point Location { get; set; }
        public MeterInfo Meter { get; set; }

        public static WeaponInfo FromXml(XElement weaponNode, string basePath)
        {
            WeaponInfo info = new WeaponInfo();
            info.Name = weaponNode.RequireAttribute("name").Value;
            info.Entity = weaponNode.RequireAttribute("entity").Value;

            info.IconOn = FilePath.FromRelative(weaponNode.RequireAttribute("on").Value, basePath);
            info.IconOff = FilePath.FromRelative(weaponNode.RequireAttribute("off").Value, basePath);

            info.Location = new Point(weaponNode.GetInteger("x"), weaponNode.GetInteger("y"));

            XElement meter = weaponNode.Element("Meter");
            if (meter != null)
            {
                info.Meter = MeterInfo.FromXml(meter, basePath);
            }

            return info;
        }
    }
}