using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace BackgroundEffect
{
    public class Effect
    {
         public static void InitializeFrostedGlass(UIElement glassHost)
    {
        //初始高斯模糊
        Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
        Compositor compositor = hostVisual.Compositor;
        var backdropBrush = compositor.CreateHostBackdropBrush();
        var glassVisual = compositor.CreateSpriteVisual();
        glassVisual.Brush = backdropBrush;
        ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);
        var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
        bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);
        glassVisual.StartAnimation("Size", bindSizeAnimation);
    }
    }
    
}
