using Microsoft.AspNetCore.SignalR;

namespace Web
{
    public class ChatHub : Hub
    {
        public async Task EnviarMensaje (int room, string usuario, string mensaje)
        {
            await Clients.Group(room.ToString()).SendAsync("RecibirMensaje", usuario, mensaje);
        }

        public async Task AgregarGrupo(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }
    }
}
