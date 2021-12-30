using System.Collections.Generic;

class AirtableResponse
{
    public List<AirtableRecord> records { get; set; }
}

class AirtableRecord
{
    public string id { get; set; }
    public AirtableRecordFields fields { get; set; }
}

/// <summary>
/// Customize this class with fields that match the structure of your database.
/// </summary>

class AirtableRecordFields
{
    public string Name { get; set; }
    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
}