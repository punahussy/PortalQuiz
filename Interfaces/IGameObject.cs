using System.Drawing;

namespace Portalquiz
{
    //Интерфейс игровых объектов
    public interface IGameObject
    {
        int X { get; }
        int Y { get; }
        int Width { get; }
        int Height { get; }
        Bitmap Texture { get; }

        void OnCollision(Player player);
    }
}
