namespace todolist_windows_form
{
    partial class uc_ticketItem
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txbTicketSubject = new System.Windows.Forms.TextBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.chkDone = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txbTicketSubject
            // 
            this.txbTicketSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicketSubject.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txbTicketSubject.Location = new System.Drawing.Point(94, 7);
            this.txbTicketSubject.Name = "txbTicketSubject";
            this.txbTicketSubject.Size = new System.Drawing.Size(403, 39);
            this.txbTicketSubject.TabIndex = 1;
            this.txbTicketSubject.Enter += new System.EventHandler(this.txbTicketSubject_Enter);
            this.txbTicketSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbTicketSubject_KeyDown);
            this.txbTicketSubject.Leave += new System.EventHandler(this.txbTicketSubject_Leave);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDetail.Location = new System.Drawing.Point(503, 4);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(88, 50);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "詳細";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // chkDone
            // 
            this.chkDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDone.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDone.FlatAppearance.BorderSize = 2;
            this.chkDone.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGray;
            this.chkDone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.chkDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDone.Location = new System.Drawing.Point(12, 7);
            this.chkDone.Name = "chkDone";
            this.chkDone.Size = new System.Drawing.Size(76, 44);
            this.chkDone.TabIndex = 3;
            this.chkDone.UseVisualStyleBackColor = true;
            this.chkDone.CheckedChanged += new System.EventHandler(this.chkDone_CheckedChanged);
            // 
            // uc_ticketItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkDone);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.txbTicketSubject);
            this.Name = "uc_ticketItem";
            this.Size = new System.Drawing.Size(604, 60);
            this.Load += new System.EventHandler(this.uc_ticketItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbTicketSubject;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.CheckBox chkDone;
    }
}
