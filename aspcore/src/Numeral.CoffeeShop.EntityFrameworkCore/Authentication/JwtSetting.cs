﻿namespace Numeral.CoffeeShop.EntityFrameworkCore.Authentication;

public class JwtSetting
{
    public const string SectioName = "JwtSetting";
    public string Secret { get; init; }
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
}