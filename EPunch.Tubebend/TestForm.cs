using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnyCAD.Platform;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace EPunch.Tubebend
{
    public partial class TestForm : Form
    {

        // Render Control
        private AnyCAD.Presentation.RenderWindow3d renderView;
        private AnyCAD.Presentation.RenderWindow3d renderViewXZ;
        private AnyCAD.Presentation.RenderWindow3d renderViewYZ;
        private AnyCAD.Presentation.RenderWindow3d renderViewDraw;
        private readonly int shapeId = 1000;
        private TopoShape topoShape = new TopoShape();
        private DataManage dataManage = new DataManage();
        public TestForm()
        {            
            InitializeComponent();
            this.renderView = new AnyCAD.Presentation.RenderWindow3d();
            this.renderViewXZ = new AnyCAD.Presentation.RenderWindow3d();
            this.renderViewYZ = new AnyCAD.Presentation.RenderWindow3d();
            this.renderViewDraw = new AnyCAD.Presentation.RenderWindow3d();
            //初始化视窗大小
            System.Drawing.Size size = this.panel1.ClientSize;
            Size sizeXZ = panel2.ClientSize;
            Size sizeYZ = panel3.ClientSize;
            Size sizeDraw = panel4.ClientSize;
            this.renderView.Size = size;
            renderViewXZ.Size = sizeXZ;
            renderViewYZ.Size = sizeYZ;
            renderViewDraw.Size = sizeDraw;

            this.renderView.TabIndex = 1;
            renderViewXZ.TabIndex = 2;
            renderViewYZ.TabIndex = 3;
            this.panel1.Controls.Add(this.renderView);
            panel2.Controls.Add(renderViewXZ);
            panel3.Controls.Add(renderViewYZ);
            panel4.Controls.Add(renderViewDraw);

            dgvBending.DataSource = dataManage.BendingSet.Tables[0];

            this.renderView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnRenderWindow_MouseClick);
            renderViewDraw.MouseClick += new MouseEventHandler(OnRenderWindow_MouseClick);

            GlobalInstance.EventListener.OnChangeCursorEvent += OnChangeCursor;
            GlobalInstance.EventListener.OnSelectElementEvent += OnSelectElement;

            dataManage.DataChange += new DataManage.DataChangeHandler(DataManage_DataChange);
        }

        private void DataManage_DataChange()
        {
            bendings.SetBendingGroup(dataManage);
        }

        private void OnSelectElement(SelectionChangeArgs args)
        {
            if (!args.IsHighlightMode())
            {
                SelectedShapeQuery query = new SelectedShapeQuery();
                renderView.QuerySelection(query);
                var shape = query.GetGeometry();
                if (shape != null)
                {
                    GeomCurve curve = new GeomCurve();
                    if (curve.Initialize(shape))
                    {
                        TopoShapeProperty property = new TopoShapeProperty();
                        property.SetShape(shape);
                        Console.WriteLine("Edge Length {0}", property.EdgeLength());
                    }
                }
            }
        }
        private void OnChangeCursor(String commandId, String cursorHint)
        {

            if (cursorHint == "Pan")
            {
                this.renderView.Cursor = System.Windows.Forms.Cursors.SizeAll;
                renderViewDraw.Cursor = Cursors.SizeAll;
            }
            else if (cursorHint == "Orbit")
            {
                this.renderView.Cursor = System.Windows.Forms.Cursors.Hand;
                renderViewDraw.Cursor = Cursors.Hand;
            }
            else if (cursorHint == "Cross")
            {
                this.renderView.Cursor = System.Windows.Forms.Cursors.Cross;
                renderViewDraw.Cursor = Cursors.Cross;
            }
            else
            {
                if (commandId == "Pick")
                {
                    this.renderView.Cursor = System.Windows.Forms.Cursors.Arrow;
                    renderViewDraw.Cursor = Cursors.Arrow;
                }
                else
                {
                    this.renderView.Cursor = System.Windows.Forms.Cursors.Default;
                    renderViewDraw.Cursor = Cursors.Default;
                }
            }

        }
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            if (renderView != null)
            {
                System.Drawing.Size size = this.panel1.ClientSize;
                renderView.Size = size;
            }
        }
        private void Panel2_SizeChanged(object sender, EventArgs e)
        {
            if (renderViewXZ != null)
            {
                renderViewXZ.Size = panel2.ClientSize;
                //try
                //{
                //    renderViewXZ.Renderer.SetStandardView(EnumStandardView.SV_Back);
                //    renderViewXZ.ExecuteCommand("Pan");
                //    renderViewXZ.RequestDraw();

                //}
                //catch (Exception)
                //{
                //    throw;
                //}
            }
        }
        private void Panel3_SizeChanged(object sender, EventArgs e)
        {
            if (renderViewYZ != null)
            {
                renderViewYZ.Size = panel3.ClientSize;
                //try
                //{
                //    renderViewYZ.Renderer.SetStandardView(EnumStandardView.SV_Right);
                //    renderViewYZ.ExecuteCommand("Pan");
                //    renderViewYZ.RequestDraw();
                //}
                //catch (Exception)
                //{
                //    throw;
                //}
            }
        }
        private void Panel4_SizeChanged(object sender, EventArgs e)
        {
            if (renderViewDraw != null)
            {
                System.Drawing.Size size = this.panel4.ClientSize;
                renderViewDraw.Size = size;
            }
        }

        private void PanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderView.ExecuteCommand("Pan");
            if (renderViewDraw != null)
            {
                renderViewDraw.ExecuteCommand("Pan"); 
            }
        }
        private void SinglePickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderView.ExecuteCommand("PickClearMode", "SinglePick");
        }
        private void MultiPickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderView.ExecuteCommand("PickClearMode", "MultiPick");
        }
        private void MouseBtn_Click(object sender, EventArgs e)
        {
            renderView.ExecuteCommand("Pick");
            if (renderViewDraw != null)
            {
                renderViewDraw.ExecuteCommand("Pick"); 
            }
        }
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renderView.ClearScene();
            renderViewXZ.ClearScene();
            renderViewYZ.ClearScene();
            if (renderViewDraw != null)
            {
                renderViewDraw.ClearScene();
                Vecs.Clear();
                //posOfStep = 0;
                //stepBendings.Clear();
                dataManage.Clear();
                dataManage.AcceptChanges();
            }
        }
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "STEP (*.stp;*.step)|*.stp;*.step|STL (*.stl)|*.stl|IGES (*.igs;*.iges)|*.igs;*.iges|BREP (*.brep)|*.brep|All Files(*.*)|*.*"
            };

            if (DialogResult.OK != dlg.ShowDialog())
                return;

            TopoShape shape = GlobalInstance.BrepTools.LoadFile(new AnyCAD.Platform.Path(dlg.FileName));
            topoShape = shape;
            #region Render Shape
            renderView.RenderTimer.Enabled = false;
            if (shape != null)
            {
                renderView.ShowGeometry(shape, shapeId);
            }
            renderView.RenderTimer.Enabled = true;
            renderView.FitAll();
            renderView.RequestDraw(EnumRenderHint.RH_LoadScene);

            #endregion 
        }

        private void MoveNodeBtn_Click(object sender, EventArgs e)
        {
            renderView.ExecuteCommand("MoveNode");
        }

        #region Draw sketch
        private bool m_PickPoint = false;
        private List<Vector3> Vecs = new List<Vector3>();
        private TopoShapeGroup EdgeG = new TopoShapeGroup();
        private void HitTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_PickPoint = !m_PickPoint;
        }
        private void OnRenderWindow_MouseClick(object sender, MouseEventArgs e)
        {
            if (!m_PickPoint)
                return;

            Vector3 pt = renderViewDraw.HitPointOnGrid(e.X, e.Y);
            if (pt != null)
            {
                if (Vecs.Count() == 0)
                {
                    Vecs.Add(pt);
                    TopoShape shape = GlobalInstance.BrepTools.MakeSphere(pt, 1);
                    renderViewDraw.ShowGeometry(shape, 100);
                }
                else
                {
                    var c = from m in Vecs
                            where m.Distance(pt) <= 1
                            select m;

                    if (c.Count() == 0)
                    {
                        var pt0 = Vecs.Last();
                        Vecs.Add(pt);
                        TopoShape shape = GlobalInstance.BrepTools.MakeSphere(pt, 1);
                        TopoShape edge = GlobalInstance.BrepTools.MakeLine(pt0, pt);
                        EdgeG.Add(edge);
                        renderViewDraw.ShowGeometry(shape, 100);
                        renderViewDraw.ShowGeometry(edge, 100);
                    }
                    else if (Vecs.First().Equals(c.Last()))
                    {
                        TopoShape edge = GlobalInstance.BrepTools.MakeLine(Vecs.Last(), Vecs.First());
                        EdgeG.Add(edge);
                        renderViewDraw.ShowGeometry(edge, 100);
                        m_PickPoint = !m_PickPoint;
                    }
                }
            }
        }

        #endregion

        private void SectionBtn_Click(object sender, EventArgs e)
        {
            TopoShape shapeXZ = new TopoShape();
            TopoShape shapeYZ = new TopoShape();
            if (topoShape != null)
            {
                shapeXZ = Section(topoShape, new Vector3(0, 1, 0));
                shapeYZ = Section(topoShape, new Vector3(1, 0, 0));
            }

            renderViewXZ.Renderer.SetStandardView(EnumStandardView.SV_Back);
            renderViewXZ.ExecuteCommand("Pan");
            renderViewYZ.Renderer.SetStandardView(EnumStandardView.SV_Right);
            renderViewYZ.ExecuteCommand("Pan");

            #region Render
            if (topoShape != null)
            {
                renderViewXZ.ClearScene();
                renderViewXZ.ShowGeometry(shapeXZ, shapeId);
                renderViewYZ.ClearScene();
                renderViewYZ.ShowGeometry(shapeYZ, shapeId);
            }
            renderViewXZ.FitAll();
            renderViewYZ.FitAll();
            renderViewXZ.RequestDraw(EnumRenderHint.RH_LoadScene);
            renderViewYZ.RequestDraw(EnumRenderHint.RH_LoadScene);
            #endregion

        }

        private void TransOnMaxBtn_Click(object sender, EventArgs e)
        {
            SelectedShapeQuery context = new SelectedShapeQuery();
            renderView.QuerySelection(context);
            var shape = context.GetGeometry();
            TransOnMax(shape);
        }

        private void TransOnMax(TopoShape shape)
        {
            double areaM = 0;
            Vector3 dirN = new Vector3();
            Vector3 pos = new Vector3();
            TopoExplor topo = new TopoExplor();
            TopoShapeGroup group2 = topo.ExplorFaces(shape);
            for (int i = 0; i < group2.Size(); i++)
            {
                TopoShape face = group2.GetTopoShape(i);

                #region 计算面积
                TopoShapeProperty property = new TopoShapeProperty();
                property.SetShape(face);
                Console.WriteLine("Face {0}:\n\tArea {1}\n\tOrientation {2}", i, property.SurfaceArea(), face.GetOrientation());
                #endregion
                #region 计算法向量
                GeomSurface surface = new GeomSurface();
                surface.Initialize(face);
                //参数域UV范围
                double uFirst = surface.FirstUParameter();
                double uLast = surface.LastUParameter();
                double vFirst = surface.FirstVParameter();
                double vLast = surface.LastVParameter();
                //取中点
                double umid = uFirst + (uLast - uFirst) * 0.5f;
                double vmid = vFirst + (vLast - vFirst) * 0.5f;
                //计算法向量
                var data = surface.D1(umid, vmid);
                Vector3 dirU = data[1];
                Vector3 dirV = data[2];
                Vector3 dir = dirV.CrossProduct(dirU);
                dir.Normalize();
                Console.WriteLine("\tDir {0}", dir);
                #endregion

                #region 取最大的面
                if (property.SurfaceArea() > areaM)
                {
                    areaM = property.SurfaceArea();
                    pos = data[0];
                    Console.WriteLine(data[0]);
                    if (face.GetOrientation() == EnumShapeOrientation.ShapeOrientation_REVERSED)
                    {
                        dirN = dir * -1;
                    }
                    else
                    {
                        dirN = dir;
                    }
                }
                #endregion
            }

            #region 坐标变换
            //Translation
            shape = GlobalInstance.BrepTools.Translate(shape, -pos);
            //Rotation
            Vector3 dirZ = new Vector3(0, 0, -1);
            shape = GlobalInstance.BrepTools.Rotation(shape, dirN.CrossProduct(dirZ), dirN.AngleBetween(dirZ));
            #endregion

            if (shape != null)
            {
                topoShape = shape;
                renderView.ClearScene();
                renderView.ShowGeometry(shape, shapeId);
            }
            renderView.FitAll();
            renderView.RequestDraw(EnumRenderHint.RH_LoadScene);

        }

        private void TransOnSelectBtn_Click(object sender, EventArgs e)
        {
            //Get selected shape
            SelectedShapeQuery context = new SelectedShapeQuery();
            renderView.QuerySelection(context);
            var shape = context.GetGeometry();
            var face = context.GetSubGeometry();
            if (shape == null)
            {
                return;
            }
            var center = shape.GetBBox().GetCenter();

            #region 计算法向量
            GeomSurface surface = new GeomSurface();
            surface.Initialize(face);
            //参数域UV范围
            double uFirst = surface.FirstUParameter();
            double uLast = surface.LastUParameter();
            double vFirst = surface.FirstVParameter();
            double vLast = surface.LastVParameter();
            //取中点
            double umid = uFirst + (uLast - uFirst) * 0.5f;
            double vmid = vFirst + (vLast - vFirst) * 0.5f;
            //计算法向量
            var data = surface.D1(umid, vmid);
            Vector3 dirU = data[1];
            Vector3 dirV = data[2];
            Vector3 dir = dirV.CrossProduct(dirU);
            dir.Normalize();
            Console.WriteLine("\tDir {0}", dir);
            #endregion

            #region 坐标变换
            Vector3 dirN = new Vector3();
            if (face.GetOrientation() == EnumShapeOrientation.ShapeOrientation_REVERSED)
            {
                dirN = dir * -1;
            }
            else
            {
                dirN = dir;
            }

            //Translation
            shape = GlobalInstance.BrepTools.Translate(shape, -center);
            //Rotation
            Vector3 dirZ = new Vector3(0, 0, -1);
            shape = GlobalInstance.BrepTools.Rotation(shape, dirN.CrossProduct(dirZ), dirN.AngleBetween(dirZ));
            #endregion

            #region Render
            if (shape != null)
            {
                topoShape = shape;
                renderView.ClearScene();
                renderView.ShowGeometry(shape, shapeId);
            }
            renderView.FitAll();
            renderView.RequestDraw(EnumRenderHint.RH_LoadScene);

            #endregion

        }
        private TopoShape Section(TopoShape shape, Vector3 dir)
        {
            Vector3 origion = new Vector3(0, 0, 0);
            TopoShape plane = GlobalInstance.BrepTools.MakePlaneFace(origion,dir,-100,100,-100,100);
            shape = GlobalInstance.BrepTools.BooleanCommon(shape, plane);
            return shape;
        }

        private BendingGroup bendings = new BendingGroup();
        private TopoShape section = new TopoShape();
        private void BtnDraw_Click(object sender, EventArgs e)
        {
            section = GlobalInstance.BrepTools.MakeCircle(Vector3.ZERO, Convert.ToDouble(txtR.Text), Vector3.UNIT_X);
        }
        private void BtnBendAdd_Click(object sender, EventArgs e)
        {
            //记录输入参数
            Bending bending = new Bending()
            {
                Direction = Convert.ToDouble(txtDir.Text),
                Angle = Convert.ToDouble(txtAngle.Text),
                Radius = Convert.ToDouble(txtRadius.Text),
                Length = Convert.ToDouble(txtLength.Text)
            };

            bendings.AddBending(bending);
            dataManage.SetBendingGroup(bendings);
            dataManage.AcceptChanges();

            if (section != null)
            {
                TopoShape centerline = CenterlineAssembly(bendings);
                TopoShape sweep = GlobalInstance.BrepTools.Sweep(section, centerline, true);

                #region 渲染
                renderViewDraw.ClearScene();
                SceneManager sceneMgr = renderViewDraw.SceneManager;
                SceneNode rootNode = GlobalInstance.TopoShapeConvert.ToSceneNode(sweep, 0.1f);
                if (rootNode != null)
                {
                    sceneMgr.AddNode(rootNode);
                }
                renderViewDraw.FitAll();
                renderViewDraw.RequestDraw(EnumRenderHint.RH_LoadScene); 
                #endregion
            }

        }

        private TopoShape CenterlineAssembly(BendingGroup bendings)
        {
            TopoShape centerline = new TopoShape();
            foreach (Bending bending in bendings.Bendings)
            {
                //转料
                centerline = GlobalInstance.BrepTools.Rotation(centerline, Vector3.UNIT_X, bending.Direction);

                //送进
                Vector3 edLine = new Vector3(-bending.Length, 0, 0);
                TopoShape line = GlobalInstance.BrepTools.MakeLine(Vector3.ZERO, edLine);
                if (centerline != null)
                {
                    centerline = GlobalInstance.BrepTools.MakeWire(centerline, line); 
                }
                else
                {
                    centerline = GlobalInstance.BrepTools.MakeWire(line);
                }
                centerline = GlobalInstance.BrepTools.Translate(centerline, -edLine);

                //弯曲
                TopoShape arc = GlobalInstance.BrepTools.MakeArc(new Vector3(0, -bending.Radius, 0), bending.Radius, 90, 90 + bending.Angle, Vector3.UNIT_Z);
                if (arc != null)
                {
                    centerline = GlobalInstance.BrepTools.MakeWire(centerline, arc); 
                }
                centerline = GlobalInstance.BrepTools.Rotation(centerline, -Vector3.UNIT_Z, bending.Angle);
                GeomCurve curve = new GeomCurve();
                curve.Initialize(centerline);
                centerline = GlobalInstance.BrepTools.Translate(centerline, -curve.GetEndPoint());
            }
            return centerline;
        }

        private void BtnExportXml_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
        private void BtnReadXml_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            ExportXml.GenerateXml(bendings,saveFileDialog1.FileName);
        }
        //private void OpenFileDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    var file = ExportXml.ReadXml(openFileDialog1.FileName);
        //    bendings.SetBendingGroup(file);
        //    dataManage.SetBendingGroup(file);
        //    dataManage.AcceptChanges();
        //    DrawBendingGroup(bendings);
        //}
        //private void BtnUnfold_Click(object sender, EventArgs e)
        //{
        //    BendingGroup group = new BendingGroup(bendings);
        //    stepBendings.Add(bendings);
        //    DrawUnfoldGroup(bendings);
        //    foreach(var item in GetStepShapes(group))
        //    {
        //        if (stepBendings.Contains(item))
        //        {
        //            break;
        //        }
        //        stepBendings.Add(new BendingGroup(item));
        //    }
        //    posOfStep = stepBendings.Count();
        //}
        //private void DrawBendingGroup(BendingGroup bends)
        //{
        //    renderViewDraw.ClearScene();

        //    #region 绘制底面
        //    TopoShape baseShape = GlobalInstance.BrepTools.FillFace(bends.Vertexes);
        //    var pressSlide = GlobalInstance.BrepTools.MakeBox(bends.Center - new Vector3(25, 10, 0), Vector3.UNIT_Z, new Vector3(50, 20, 10));

        //    SceneManager sceneMgr = renderViewDraw.SceneManager;
        //    SceneNode root = GlobalInstance.TopoShapeConvert.ToSceneNode(baseShape, 0.1f);
        //    SceneNode slideNode = GlobalInstance.TopoShapeConvert.ToSceneNode(pressSlide, 0.1f);
        //    sceneMgr.AddNode(root);
        //    sceneMgr.AddNode(slideNode);
        //    #endregion

        //    #region 按逆时针方向依次折弯
        //    //var oris = bends.Bendings.OrderBy(m => m.Orientation).Select(m => m.Orientation).Distinct();
        //    Queue<Vector3> vertexQueue = new Queue<Vector3>(bends.Vertexes);
        //    for (int i = 0; i < vertexQueue.Count(); i++)
        //    {
        //        var sPt = vertexQueue.Dequeue();
        //        var ePt = vertexQueue.Peek();
        //        vertexQueue.Enqueue(sPt);
        //        var line = GlobalInstance.BrepTools.MakeLine(sPt, ePt);
        //        var face = baseShape;
        //        var groupEdge = from m in bends.Bendings
        //                        where m.Orientation == Math.Round(((ePt - sPt).Y >= 0 ? (ePt - sPt).AngleBetween(Vector3.UNIT_X) : (360 - (ePt - sPt).AngleBetween(Vector3.UNIT_X))), 3)
        //                        orderby m.Index
        //                        select m;
        //        foreach (var bending in groupEdge)
        //        {
        //            if (face == null || line == null)
        //            {
        //                return;
        //            }
        //            if (face.GetShapeType() != EnumTopoShapeType.Topo_FACE || line.GetShapeType() != EnumTopoShapeType.Topo_EDGE)
        //            {
        //                break;
        //            }
        //            BendHelper helper = new BendHelper();
        //            if (bending.Direction.Equals(EnumDir.Edge_UP))
        //            {
        //                helper = BendUp(face, line, bending);
        //            }
        //            else
        //            {
        //                helper = BendDown(face, line, bending);
        //            }
        //            ElementId id = new ElementId(bending.Index);
        //            SceneNode node = GlobalInstance.TopoShapeConvert.ToSceneNode(helper.Sweep, 0.1f);
        //            node.SetId(id);
        //            sceneMgr.AddNode(node);
        //            face = helper.EdFace;
        //            line = helper.EdLine;
        //        }

        //    } 
        //    #endregion

        //    renderViewDraw.FitAll();
        //    renderViewDraw.RequestDraw(EnumRenderHint.RH_LoadScene);

        //}
        //private void DrawUnfoldGroup(BendingGroup bends)
        //{
        //    renderViewDraw.ClearScene();
            
        //    #region 绘制底面
        //    TopoShape baseShape = GlobalInstance.BrepTools.FillFace(bends.Vertexes);
        //    var pressSlide = GlobalInstance.BrepTools.MakeBox(bends.Center - new Vector3(25, 10, 0), Vector3.UNIT_Z, new Vector3(50, 20, 10));

        //    SceneManager sceneMgr = renderViewDraw.SceneManager;
        //    SceneNode root = GlobalInstance.TopoShapeConvert.ToSceneNode(baseShape, 0.1f);
        //    SceneNode slideNode = GlobalInstance.TopoShapeConvert.ToSceneNode(pressSlide, 0.1f);
            
        //    sceneMgr.AddNode(root);
        //    sceneMgr.AddNode(slideNode);
        //    #endregion

        //    #region 按逆时针方向依次折弯
        //    Queue<Vector3> vertexQueue = new Queue<Vector3>(bends.Vertexes);
        //    for (int i = 0; i < vertexQueue.Count(); i++)
        //    {
        //        var sPt = vertexQueue.Dequeue();
        //        var ePt = vertexQueue.Peek();
        //        vertexQueue.Enqueue(sPt);
        //        var line = GlobalInstance.BrepTools.MakeLine(sPt, ePt);
        //        var face = baseShape;
        //        var groupEdge = from m in bends.Bendings
        //                        where m.Orientation == Math.Round(((ePt - sPt).Y >= 0 ? (ePt - sPt).AngleBetween(Vector3.UNIT_X) : (360 - (ePt - sPt).AngleBetween(Vector3.UNIT_X))), 3)
        //                        orderby m.Index
        //                        select m;
        //        foreach (var bending in groupEdge)
        //        {
        //            if (face == null || line == null)
        //            {
        //                return;
        //            }
        //            if (face.GetShapeType() != EnumTopoShapeType.Topo_FACE || line.GetShapeType() != EnumTopoShapeType.Topo_EDGE)
        //            {
        //                break;
        //            }
        //            BendHelper helper = new BendHelper();
        //            var temp = new Bending(bending);
        //            temp.Length += temp.Radius * temp.Angle * Math.PI / 180;
        //            temp.Angle = 0;
        //            helper = BendUp(face, line, temp);
        //            ElementId id = new ElementId(bending.Index);
        //            SceneNode node = GlobalInstance.TopoShapeConvert.ToSceneNode(helper.Sweep, 0.1f);
        //            node.SetId(id);
        //            sceneMgr.AddNode(node);
        //            face = helper.EdFace;
        //            line = helper.EdLine;
        //        }

        //    }
        //    #endregion

        //    renderViewDraw.FitAll();
        //    renderViewDraw.RequestDraw(EnumRenderHint.RH_LoadScene);

        //}
        //private static IEnumerable<BendingGroup> GetStepShapes(BendingGroup bends)
        //{
        //    BendingGroup group = new BendingGroup(bends);
        //    List<Bending> temp = new List<Bending>(group.Bendings.OrderBy(m => m.Index).ToList());
        //    foreach(var item in temp)
        //    {
        //        item.Length += item.Radius * item.Angle * Math.PI / 180;
        //        item.Angle = 0;
        //        group.Bendings = temp;
        //        yield return group;
        //    }
        //}
        //private int posOfStep = 0;
        //private List<BendingGroup> stepBendings = new List<BendingGroup>();
        //private void BtnNext_Click(object sender, EventArgs e)
        //{
        //    if (posOfStep <= 0)
        //    {
        //        return;
        //    }
        //    var item = stepBendings.ElementAt(--posOfStep);
        //    DrawBendingGroup(item);
        //}
        //private void BtnLast_Click(object sender, EventArgs e)
        //{
        //    if (posOfStep >= stepBendings.Count())
        //    {
        //        return;
        //    }
        //    var item = stepBendings.ElementAt(posOfStep++);
        //    DrawBendingGroup(item);
        //}
        //private void ReorderBendings(BendingGroup bends)
        //{
        //    var temp = bends.Bendings.OrderBy(m => m.Orientation).ThenBy(m => m.Index).ToList();
        //    int i = 0;
        //    foreach(var item in temp)
        //    {
        //        item.Index = i++;
        //    }
        //    bends.Bendings = temp;
        //    dataManage.SetBendingGroup(bends);
        //    dataManage.AcceptChanges();
        //}

        //private void BtnReorder_Click(object sender, EventArgs e)
        //{
        //    ReorderBendings(bendings);
        //}
    }
}


