# dev 分支的变更说明
 * 修改 为在 linux 下通过 mono 运行，修改项目输出为 netframework4.7.2;net6.0-windows，为兼容同步修改 split() 的调用方式, [^1] 改为 .Last()
 * 修改 输出源代码的内容，保存时可自动生成 Form***.cs
 * 修改 事件表格的界面样式，解决标题栏双击报错的问题
 * 修正 多处 ***_Click() 事件为 ***_MouseClick()，解决强制转换 EventArgs 为 MouseEventArgs 出错的问题
 * 修正 Form 重命名无效的问题

# SWD4CS
 * SWD4CSは、Simple WinForms Designer for CSharp (VSCode)の略  
 * VisualStudioは重いので、VSCodeをよく使う。がデザイナがない。  
 * デザイナの作り方が全く分からず、思い付くままに書いてみた。  
 * この作り方では複雑なものは無理。ちょっとしたツール程度なら使えるかも？

 * SWD4CS 是 Simple WinForms Designer for CSharp (VSCode) 的缩写。 
 * 由于 Visual Studio 较重，因此经常使用 VSCode，但 VSCode 没有设计师功能。 
 * 完全不知道如何制作设计师功能，只是凭直觉尝试编写。 
 * 用这种方法可能无法处理复杂的东西，但对于一些小工具来说可能还是有用的。
  
## 開発環境
 * Windows11 Home  
 * VisualStudio2022 C# → VSCode .net6.0
 
## スクリーンショット  (屏幕截图)
![SWD4CS](https://user-images.githubusercontent.com/86605611/152679486-e8f7bbed-69b4-4186-b402-35d7bd2fec8f.png)
![SWD4CS](https://user-images.githubusercontent.com/86605611/152784518-c135ec3a-e156-4163-8f8d-90cc023d8448.png)
※ControlTreeは表示のみ  (控件节点树仅用于显示)


## 動画
 https://youtu.be/BJAhuU2W3uM  
 https://youtu.be/3LyjAvXLpYg  
 https://youtu.be/82qa0vOP_qk  
 https://youtu.be/FkDaMW4hGyk
 
## ブログ(blog)
 https://danpapa-hry.hateblo.jp/entry/2022/02/23/210416
 
## 実装(实现)
 ・ポトペタ  
 ・一部のプロパティ変更  (部分属性更改)
 ・Button  
 ・CheckBox  
 ・CheckedListBox  
 ・ComboBox  
 ・DataGridView  
 ・DateTimePicker  
 ・DomainUpDown  
 ・FlowLayoutPanel  
 ・GroupBox  
 ・HScrollBar  
 ・Label  
 ・LinkLabel  
 ・ListBox  
 ・ListView  
 ・MaskedTextBox  
 ・MonthCalender  
 ・Panel  
 ・PictureBox  
 ・ProgressBar  
 ・PropertyGrid  
 ・RadioButton  
 ・RichTextBox  
 ・SplitContainer  
 ・Splitter  
 ・StatusStrip  
 ・TabControl  
 ・TableLayoutPanel  
 ・TabPage  
 ・TextBox  
 ・TrackBar  
 ・TreeView  
 ・VScrollBar  
 ・ColorDialog  
 ・FolderBrowserDialog  
 ・FontDialog  
 ・imageList  
 ・OpenFiledialog  
 ・SaveFiledialog  
 ・Timer  
 ・Designer.csファイルのRead/Write　~~（ただし、SWD4CS以外で編集したものは開けない）~~  (Designer.cs 文件的读取/写入~~（但是，不能打开在 SWD4CS 之外编辑的内容）~~)
 ・他のコントローラー等は必要になったら追加する。(如果需要，可以添加其他控制器等。)

## 対応プロパティ（Type）
 ・System.Drawing.Point  
 ・System.Drawing.Size  
 ・System.String  
 ・System.Boolean  
 ・System.Int32  
 ・System.Windows.Forms.AnchorStyles  
 ・System.Windows.Forms.DockStyle  
 ・System.Drawing.ContentAlignment  
 ・System.Windows.Forms.ScrollBars  
 ・System.Windows.Forms.HorizontalAlignment  
 ・System.Drawing.Color  
 ・System.Windows.Forms.FormStartPosition  
 ・System.Windows.Forms.FormWindowState  
 ・System.Windows.Forms.FixedPanel  
 ・System.Windows.Forms.PictureBoxSizeMode  
 ・System.Windows.Forms.View  
 ・System.Windows.Forms.Orientation  
 ・System.Windows.Forms.FormBorderStyle  
 ・System.Windows.Forms.AutoScaleMode  
 ・System.Drawing.Font  
 ・System.Windows.Forms.TableLayoutPanelCellBorderStyle  

## コントロール追加方法  (控件添加方法)
 * 「// コントロール追加時に下記を編集すること」に追記  (在「// 添加控件时请编辑以下内容」处追加)
・cls_control.cs  
