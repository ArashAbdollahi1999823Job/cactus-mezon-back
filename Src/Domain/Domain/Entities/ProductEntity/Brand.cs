﻿namespace Domain.Entities.ProductEntity;
public class Brand:BaseEntity.BaseEntity
{
    #region Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public string MetaDescription { get; set; }
    public string Summary { get; set; }
    #endregion

    public Brand(string name, string description, string metaDescription, string summary)
    {
        Name = name;
        Description = description;
        MetaDescription = metaDescription;
        Summary = summary;
    }

    #region Relations

    public List<Product> Products { get; set; }
    #endregion
}

