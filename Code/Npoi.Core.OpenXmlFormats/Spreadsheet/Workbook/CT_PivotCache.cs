﻿using Npoi.Core.OpenXml4Net.OPC;
using Npoi.Core.OpenXml4Net.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Npoi.Core.OpenXmlFormats.Spreadsheet
{
    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class CT_PivotCaches
    {

        private List<CT_PivotCache> pivotCacheField;

        public CT_PivotCaches()
        {
            //this.pivotCacheField = new List<CT_PivotCache>();
        }
        public static CT_PivotCaches Parse(XElement node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_PivotCaches ctObj = new CT_PivotCaches();
            ctObj.pivotCache = new List<CT_PivotCache>();
            foreach (XElement childNode in node.ChildElements())
            {
                if (childNode.Name.LocalName == "pivotCache")
                    ctObj.pivotCache.Add(CT_PivotCache.Parse(childNode, namespaceManager));
            }
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<{0}", nodeName));
            sw.Write(">");
            if (this.pivotCache != null)
            {
                foreach (CT_PivotCache x in this.pivotCache)
                {
                    x.Write(sw, "pivotCache");
                }
            }
            sw.Write(string.Format("</{0}>", nodeName));
        }
        [XmlElement]
        public List<CT_PivotCache> pivotCache
        {
            get
            {
                return this.pivotCacheField;
            }
            set
            {
                this.pivotCacheField = value;
            }
        }

        public CT_PivotCache AddNewPivotCache()
        {
            if (this.pivotCacheField == null)
                this.pivotCacheField = new List<CT_PivotCache>();
            CT_PivotCache c = new CT_PivotCache();
            this.pivotCacheField.Add(c);
            return c;
        }

        public CT_PivotCache GetPivotCacheArray(int p)
        {
            if (pivotCacheField == null || p < 0 || p >= pivotCacheField.Count)
                return null;
            return pivotCacheField[p];
        }
    }
    [Serializable]
    [XmlType(Namespace = "http://schemas.openxmlformats.org/spreadsheetml/2006/main")]
    public class CT_PivotCache
    {

        private uint cacheIdField;

        private string idField;
        public static CT_PivotCache Parse(XElement node, XmlNamespaceManager namespaceManager)
        {
            if (node == null)
                return null;
            CT_PivotCache ctObj = new CT_PivotCache();
            ctObj.cacheId = XmlHelper.ReadUInt(node.Attribute("cacheId"));
            ctObj.id = XmlHelper.ReadString(node.Attribute((XNamespace)PackageNamespaces.SCHEMA_RELATIONSHIPS + "id"));
            return ctObj;
        }



        internal void Write(StreamWriter sw, string nodeName)
        {
            sw.Write(string.Format("<{0}", nodeName));
            XmlHelper.WriteAttribute(sw, "cacheId", this.cacheId);
            XmlHelper.WriteAttribute(sw, "r:id", this.id);
            sw.Write(">");
            sw.Write(string.Format("</{0}>", nodeName));
        }
        [XmlAttribute]
        public uint cacheId
        {
            get
            {
                return this.cacheIdField;
            }
            set
            {
                this.cacheIdField = value;
            }
        }
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.openxmlformats.org/officeDocument/2006/relationships")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

}
