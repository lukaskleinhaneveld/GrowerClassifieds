using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GrowersClassified.Models
{
    public class Dimensions
    {
        public string length { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }

    public class Image
    {
        public int? id { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_created_gmt { get; set; }
        public DateTime? date_modified { get; set; }
        public DateTime? date_modified_gmt { get; set; }
        public string src { get; set; }
        public string name { get; set; }
        public string alt { get; set; }
        public int? position { get; set; }
    }

    public class MetaData
    {
        public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Collection
    {
        public string href { get; set; }
    }

    public class Links
    {
        public List<Self> self { get; set; }
        public List<Collection> collection { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string permalink { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_created_gmt { get; set; }
        public DateTime? date_modified { get; set; }
        public DateTime? date_modified_gmt { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public bool featured { get; set; }
        public string catalog_visibility { get; set; }
        public string description { get; set; }
        public string short_description { get; set; }
        public string sku { get; set; }
        public string price { get; set; }
        public string regular_price { get; set; }
        public string sale_price { get; set; }
        public object date_on_sale_from { get; set; }
        public object date_on_sale_from_gmt { get; set; }
        public object date_on_sale_to { get; set; }
        public object date_on_sale_to_gmt { get; set; }
        public string price_html { get; set; }
        public bool on_sale { get; set; }
        public bool purchasable { get; set; }
        public int total_sales { get; set; }
        public bool @virtual { get; set; }
        public bool downloadable { get; set; }
        public List<object> downloads { get; set; }
        public int download_limit { get; set; }
        public int download_expiry { get; set; }
        public string external_url { get; set; }
        public string button_text { get; set; }
        public string tax_status { get; set; }
        public string tax_class { get; set; }
        public bool manage_stock { get; set; }
        public object stock_quantity { get; set; }
        public bool in_stock { get; set; }
        public string backorders { get; set; }
        public bool backorders_allowed { get; set; }
        public bool backordered { get; set; }
        public bool sold_individually { get; set; }
        public string weight { get; set; }
        public Dimensions dimensions { get; set; }
        public bool shipping_required { get; set; }
        public bool shipping_taxable { get; set; }
        public string shipping_class { get; set; }
        public int shipping_class_id { get; set; }
        public bool reviews_allowed { get; set; }
        public string average_rating { get; set; }
        public int rating_count { get; set; }
        public List<int> related_ids { get; set; }
        public List<object> upsell_ids { get; set; }
        public List<object> cross_sell_ids { get; set; }
        public int parent_id { get; set; }
        public string purchase_note { get; set; }
        public List<Category> categories { get; set; }
        public List<object> tags { get; set; }
        public List<Image> images { get; set; }
        public List<object> attributes { get; set; }
        public List<object> default_attributes { get; set; }
        public List<object> variations { get; set; }
        public List<object> grouped_products { get; set; }
        public int menu_order { get; set; }
        public List<MetaData> meta_data { get; set; }
        public Links _links { get; set; }

        public Product(string Title, string Price, string Description, string Short_Description, List<Category> Categories)
        {
            this.name = Title;
            this.regular_price = Price;
            this.description = Description;
            this.short_description = Short_Description;
            this.categories = Categories;
        }

        //public Product(int id, string name, string slug, string permalink, DateTime date_created, DateTime date_created_gmt, DateTime date_modified, DateTime date_modified_gmt, string type, string status, bool featured, string catalog_visibility, string description, string short_description, string sku, decimal? price, decimal? regular_price, double? sale_price, object date_on_sale_from, object date_on_sale_from_gmt, object date_on_sale_to, object date_on_sale_to_gmt, string price_html, bool on_sale, bool purchasable, int total_sales, bool Virtual, bool downloadable, List<object> downloads, int download_limit, int download_expiry, string external_url, string button_text, string tax_status, string tax_class, bool manage_stock, string stock_quantity, bool in_stock, string backorders, bool backorders_allowed, bool backordered, bool sold_individually, string weight, Dimensions dimensions, bool shipping_required, bool shipping_taxable, string shipping_class, int shipping_class_id, bool reviews_allowed, string average_rating, int rating_count, List<int> related_ids, List<object> upsell_ids, List<object> cross_sell_ids, int parent_id, string purchase_note, List<Category> categories, List<object> tags, List<Image> images, List<object> attributes, List<object> default_attributes, List<object> variations, List<object> grouped_products, int menu_order, List<MetaData> meta_data, Links links)
        //{
        //    this.id = id;
        //    this.name = name;
        //    this.slug = slug;
        //    this.permalink = permalink;
        //    this.date_created = date_created;
        //    this.date_created_gmt = date_created_gmt;
        //    this.date_modified = date_modified;
        //    this.date_modified_gmt = date_modified_gmt;
        //    this.type = type;
        //    this.status = status;
        //    this.featured = featured;
        //    this.catalog_visibility = catalog_visibility;
        //    this.description = description;
        //    this.short_description = short_description;
        //    this.sku = sku;
        //    this.price = Convert.ToDouble(price);
        //    this.regular_price = Convert.ToDouble(regular_price);
        //    this.sale_price = Convert.ToDouble(sale_price);
        //    this.date_on_sale_from = date_on_sale_from;
        //    this.date_on_sale_from_gmt = date_on_sale_from_gmt;
        //    this.date_on_sale_to = date_on_sale_to;
        //    this.date_on_sale_to_gmt = date_on_sale_to_gmt;
        //    this.price_html = price_html;
        //    this.on_sale = on_sale;
        //    this.purchasable = purchasable;
        //    this.total_sales = total_sales;
        //    this.@virtual = Virtual;
        //    this.downloadable = downloadable;
        //    this.downloads = downloads;
        //    this.download_limit = download_limit;
        //    this.download_expiry = download_expiry;
        //    this.external_url = external_url;
        //    this.button_text = button_text;
        //    this.tax_status = tax_status;
        //    this.tax_class = tax_class;
        //    this.manage_stock = manage_stock;
        //    this.stock_quantity = stock_quantity;
        //    this.in_stock = in_stock;
        //    this.backorders = backorders;
        //    this.backorders_allowed = backorders_allowed;
        //    this.backordered = backordered;
        //    this.sold_individually = sold_individually;
        //    this.weight = weight;
        //    this.dimensions = dimensions;
        //    this.shipping_required = shipping_required;
        //    this.shipping_taxable = shipping_taxable;
        //    this.shipping_class = shipping_class;
        //    this.shipping_class_id = shipping_class_id;
        //    this.reviews_allowed = reviews_allowed;
        //    this.average_rating = average_rating;
        //    this.rating_count = rating_count;
        //    this.related_ids = related_ids;
        //    this.upsell_ids = upsell_ids;
        //    this.cross_sell_ids = cross_sell_ids;
        //    this.parent_id = parent_id;
        //    this.purchase_note = purchase_note;
        //    this.categories = categories;
        //    this.tags = tags;
        //    this.images = images;
        //    this.attributes = attributes;
        //    this.default_attributes = default_attributes;
        //    this.variations = variations;
        //    this.grouped_products = grouped_products;
        //    this.menu_order = menu_order;
        //    this.meta_data = meta_data;
        //    this._links = links;
        //}
    }
}