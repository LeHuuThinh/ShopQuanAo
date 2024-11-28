namespace ShopQuanAo
{
    partial class ChiTietDSMatHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateMH = new System.Windows.Forms.Button();
            this.btnAddMH = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvDSMH_CT = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSLMH = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTongSL = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lblTongSL);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblSLMH);
            this.groupBox1.Controls.Add(this.btnUpdateMH);
            this.groupBox1.Controls.Add(this.btnAddMH);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(899, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnUpdateMH
            // 
            this.btnUpdateMH.Location = new System.Drawing.Point(191, 66);
            this.btnUpdateMH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateMH.Name = "btnUpdateMH";
            this.btnUpdateMH.Size = new System.Drawing.Size(136, 33);
            this.btnUpdateMH.TabIndex = 8;
            this.btnUpdateMH.Text = "Sửa mặt hàng";
            this.btnUpdateMH.UseVisualStyleBackColor = true;
            this.btnUpdateMH.Click += new System.EventHandler(this.btnUpdateMH_Click);
            // 
            // btnAddMH
            // 
            this.btnAddMH.Location = new System.Drawing.Point(23, 66);
            this.btnAddMH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddMH.Name = "btnAddMH";
            this.btnAddMH.Size = new System.Drawing.Size(136, 33);
            this.btnAddMH.TabIndex = 7;
            this.btnAddMH.Text = "Thêm mặt hàng";
            this.btnAddMH.UseVisualStyleBackColor = true;
            this.btnAddMH.Click += new System.EventHandler(this.btnAddMH_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(702, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tổng số lượng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(702, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Có";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(472, 29);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 24);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(152, 30);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(286, 22);
            this.txtSearch.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên mặt hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvDSMH_CT);
            this.groupBox2.Location = new System.Drawing.Point(3, 124);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(899, 498);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách mặt hàng";
            // 
            // lvDSMH_CT
            // 
            this.lvDSMH_CT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvDSMH_CT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDSMH_CT.FullRowSelect = true;
            this.lvDSMH_CT.GridLines = true;
            this.lvDSMH_CT.HideSelection = false;
            this.lvDSMH_CT.Location = new System.Drawing.Point(3, 17);
            this.lvDSMH_CT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvDSMH_CT.Name = "lvDSMH_CT";
            this.lvDSMH_CT.Size = new System.Drawing.Size(893, 479);
            this.lvDSMH_CT.TabIndex = 0;
            this.lvDSMH_CT.UseCompatibleStateImageBehavior = false;
            this.lvDSMH_CT.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID hàng";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên mặt hàng";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Giá bán sỉ";
            this.columnHeader5.Width = 85;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Giá bán lẻ";
            this.columnHeader6.Width = 85;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Số lượng";
            this.columnHeader7.Width = 55;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Trạng thái";
            this.columnHeader8.Width = 65;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ghi chú";
            this.columnHeader9.Width = 100;
            // 
            // lblSLMH
            // 
            this.lblSLMH.AutoSize = true;
            this.lblSLMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLMH.Location = new System.Drawing.Point(738, 33);
            this.lblSLMH.Name = "lblSLMH";
            this.lblSLMH.Size = new System.Drawing.Size(24, 20);
            this.lblSLMH.TabIndex = 9;
            this.lblSLMH.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(777, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "mặt hàng";
            // 
            // lblTongSL
            // 
            this.lblTongSL.AutoSize = true;
            this.lblTongSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongSL.Location = new System.Drawing.Point(839, 72);
            this.lblTongSL.Name = "lblTongSL";
            this.lblTongSL.Size = new System.Drawing.Size(24, 20);
            this.lblTongSL.TabIndex = 11;
            this.lblTongSL.Text = "...";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(424, 67);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(136, 33);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa mặt hàng";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ChiTietDSMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 625);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChiTietDSMatHang";
            this.Text = "Danh sách mặt hàng";
            this.Load += new System.EventHandler(this.ChiTietDSMH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateMH;
        private System.Windows.Forms.Button btnAddMH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvDSMH_CT;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label lblTongSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSLMH;
        private System.Windows.Forms.Button btnDelete;
    }
}