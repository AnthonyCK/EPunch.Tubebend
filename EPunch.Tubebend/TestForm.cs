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


            GlobalInstance.EventListener.OnChangeCursorEvent += OnChangeCursor;
            GlobalInstance.EventListener.OnSelectElementEvent += OnSelectElement;

            dataManage.DataChange += new DataManage.DataChangeHandler(DataManage_DataChange);
        }

        #region Basic Setup
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
        #endregion

        private BendingGroup bendings = new BendingGroup();
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            bendings.SecShape = GlobalInstance.BrepTools.MakeCircle(Vector3.ZERO, Convert.ToDouble(txtR.Text), Vector3.UNIT_X);
            bendings.Thickness = Convert.ToDouble(txtThick.Text);
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

            #region 绘制图像
            if (bendings.SecShape != null)
            {
                TopoShape centerline = CenterlineAssembly(bendings);
                TopoShape sweep = GlobalInstance.BrepTools.Sweep(bendings.SecShape, centerline, true);

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
            #endregion
        }
        private void BtnBendDel_Click(object sender, EventArgs e)
        {
            if(dgvBending.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow row in dgvBending.SelectedRows)
                {
                    bendings.DelBending(row.Index);
                }
                dataManage.SetBendingGroup(bendings);
                dataManage.AcceptChanges();
            }

            #region 绘制图像
            if (bendings.SecShape != null)
            {
                TopoShape centerline = CenterlineAssembly(bendings);
                TopoShape sweep = GlobalInstance.BrepTools.Sweep(bendings.SecShape, centerline, true);

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
            #endregion
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            #region 绘制图像
            if (bendings.SecShape != null)
            {
                TopoShape centerline = CenterlineAssembly(bendings);
                TopoShape sweep = GlobalInstance.BrepTools.Sweep(bendings.SecShape, centerline, true);

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
            #endregion
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            dataManage.AcceptChanges();
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;

            #region 绘制图像
            if (bendings.SecShape != null)
            {
                TopoShape centerline = CenterlineAssembly(bendings);
                TopoShape sweep = GlobalInstance.BrepTools.Sweep(bendings.SecShape, centerline, true);

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
            #endregion

        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            dataManage.BendingSet.Tables[0].RejectChanges();
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
        }
        private void DgvBending_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (dgvBending.SelectedRows.Count != 0)
            {
                DataGridViewRow row = dgvBending.SelectedRows.Cast<DataGridViewRow>().ToList().Last();
                Bending bending = new Bending()
                {
                    Direction = Convert.ToDouble(txtDir.Text),
                    Angle = Convert.ToDouble(txtAngle.Text),
                    Radius = Convert.ToDouble(txtRadius.Text),
                    Length = Convert.ToDouble(txtLength.Text)
                };
                DataRow newRow = dataManage.ConvertToRow(bending);
                dataManage.BendingSet.Tables[0].Rows.InsertAt(newRow, row.Index + 1);
                dataManage.UpdateIndex();
                dataManage.AcceptChanges();

                #region 绘制图像
                if (bendings.SecShape != null)
                {
                    TopoShape centerline = CenterlineAssembly(bendings);
                    TopoShape sweep = GlobalInstance.BrepTools.Sweep(bendings.SecShape, centerline, true);

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
            ExportXml.GenerateXml(bendings, saveFileDialog1.FileName);
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


