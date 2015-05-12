﻿using Newtonsoft.Json;
using System;

namespace WebVella.ERP.Api.Models
{
    public class EmailField : Field
    {
        [JsonProperty(PropertyName = "fieldType")]
        public static FieldType FieldType { get { return FieldType.EmailField; } }

        [JsonProperty(PropertyName = "defaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty(PropertyName = "maxLength")]
        public int? MaxLength { get; set; }

        public EmailField()
        {
        }

        public EmailField(Field field) : base(field)
        {
        }

        public EmailField(InputField field) : base(field)
        {
            DefaultValue = (string)field["defaultValue"];
            MaxLength = (int?)field["maxLength"];
        }
    }

    public class EmailFieldMeta : EmailField, IFieldMeta
    {
        [JsonProperty(PropertyName = "entityId")]
        public Guid EntityId { get; set; }

        [JsonProperty(PropertyName = "entityName")]
        public string EntityName { get; set; }

        [JsonProperty(PropertyName = "parentFieldName")]
        public string ParentFieldName { get; set; }

        public EmailFieldMeta(Guid entityId, string entityName, EmailField field, string parentFieldName = null) : base(field)
        {
            EntityId = entityId;
			EntityName = entityName;
			DefaultValue = field.DefaultValue;
			MaxLength = field.MaxLength;
            ParentFieldName = parentFieldName;
        }
	}
}