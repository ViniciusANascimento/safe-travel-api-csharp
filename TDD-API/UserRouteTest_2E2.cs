using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TDD_API;

public class UserRouteTest_2E2
{
    private UserController _userController;

    public UserRouteTest_2E2()
    {
        _userController = new UserController();
    }

    [Fact]
    public void validar_rota_user()
    {
        _userController = new UserController();
        var result = _userController.Get();
        Assert.NotNull(result);
    }

    [Fact]
    public void retornarUmUsuario()
    {
        var controller = _userController.GetUsers(1);
        var okResult = Assert.IsType<OkObjectResult>(controller);
        dynamic usuario = okResult.Value;

        Assert.Equal("João", usuario.name);
        Assert.Equal("1", usuario.id);
        Assert.Equal("joao@email.com", usuario.email);
        Assert.NotEmpty(usuario.created_at);
        Assert.NotEmpty(usuario.update_at);
        Assert.DoesNotContain("password", usuario);
    }

    // [Fact]
    // public void retornarTodosUsuarios()
    // {
    //     var usuarios = _userController.GetUsers();
    //     Assert.IsType<OkObjectResult>(usuarios);
    //     Assert.IsType<List<object>>(usuarios);
    // }
}
