using Assets.Scripts.Base;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UnityBase {
  #region ITextureHandler

  public interface ITextureHandler<T> {
    void UpdateMarkerTexture(T item, SpriteRenderer renderer);

    Texture2D GetTexture(T ent);

    Texture2D GetNullTexture();
  }

  #endregion ITextureHandler

  #region TextureHandler

  /// <summary>
  /// Abstract class for texture replacement and changes in textures
  /// </summary>
  public class TextureHandler {

    public void UpdateTexture(string itemName, SpriteRenderer renderer, string resourceFolder) {
      if (!_textureDict.TryGetValue(itemName, out var newTexture)) {
        newTexture = Resources.Load<Texture2D>($"{resourceFolder}/{itemName}");
        _textureDict[itemName] = newTexture;
      }
      ReplaceTexture(renderer, newTexture);
    }

    public static void ReplaceTexture(SpriteRenderer renderer, Texture2D newTexture) {
      Assert.NotNull(renderer, "renderer");
      Assert.NotNull(renderer.sprite, "oldSprite");
      Assert.NotNull(newTexture, "newTexture");
      renderer.sprite = Sprite.Create(newTexture, renderer.sprite.rect, new Vector2(0.5f, 0.5f));
      renderer.sprite.name = newTexture.name;
    }

    public void UpdateTexture(string itemName, Image image, string resourceFolder) {
      if (!_textureDict.TryGetValue(itemName, out var newTexture)) {
        newTexture = Resources.Load<Texture2D>($"{resourceFolder}/{itemName}");
        _textureDict[itemName] = newTexture;
      }
      ReplaceTexture(image, newTexture);
    }

    public static void ReplaceTexture(Image image, Texture2D newTexture) {
      Assert.NotNull(image, "image");
      Assert.NotNull(newTexture, "newTexture");
      var sprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
      sprite.name = newTexture.name;
      image.type = Image.Type.Simple;
      image.sprite = sprite;
    }

    private readonly Dictionary<string, Texture2D> _textureDict = new();
  }

  #endregion
}