using Microsoft.AspNetCore.Components;
using MyAppTestVite.Application.Models;

namespace MyAppTestVite.Pages.Shared;

public partial class NavMenu
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout?.User;
}
