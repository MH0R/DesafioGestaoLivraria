﻿namespace DesafioGestaoLivraria.Communication.Requests;

public class RequestBookUpdateJson
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }

    public decimal? Price { get; set; }

    public int Stock { get; set; }
}