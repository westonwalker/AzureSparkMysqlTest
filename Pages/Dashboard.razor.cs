using Microsoft.AspNetCore.Components;
using MyAppTestVite.Application.Models;
using MyAppTestVite.Pages.Shared;

namespace MyAppTestVite.Pages;

public partial class Dashboard
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout.User;
}
