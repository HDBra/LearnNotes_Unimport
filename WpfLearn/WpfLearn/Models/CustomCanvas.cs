using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfLearn.Models
{
    public class CustomCanvas : ZoomableCanvas
    {
        private List<CustomVisual> visuals = new List<CustomVisual>();
        private static object locked = new object();

        /// <summary>
        /// 获取所有的child visual的数量
        /// </summary>
        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }

        /// <summary>
        /// 获取指定索引位置的visual
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }

        /// <summary>
        /// 添加一个visual
        /// </summary>
        /// <param name="visual"></param>
        public void AddVisual(CustomVisual visual)
        {
            visuals.Add(visual);
            //添加一个子视图
            base.AddVisualChild(visual);
            //添加到父视图的逻辑树中
            base.AddLogicalChild(visual);
        }

        /// <summary>
        /// 删除一个visual
        /// </summary>
        /// <param name="visual"></param>
        public void DeleteVisual(CustomVisual visual)
        {
            visuals.Remove(visual);
            //删除一个子视图
            base.RemoveVisualChild(visual);
            //从父元素的逻辑树中删除visual
            base.RemoveLogicalChild(visual);
        }


        public CustomVisual GetVisual(Point point)
        {
            HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
            return hitResult.VisualHit as CustomVisual;
        }

        private List<CustomVisual> hits = new List<CustomVisual>();

        public List<CustomVisual> GetVisuals(Geometry region)
        {
            hits.Clear();
            GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
            HitTestResultCallback callback = new HitTestResultCallback(this.HitTestCallback);
            VisualTreeHelper.HitTest(this, null, callback, parameters);
            return hits.ToList();
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {

            GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
            CustomVisual visual = result.VisualHit as CustomVisual;
            if (visual != null &&
                geometryResult.IntersectionDetail == IntersectionDetail.FullyInside)
            {
                hits.Add(visual);
            }
            return HitTestResultBehavior.Continue;
        } 

    }
}
