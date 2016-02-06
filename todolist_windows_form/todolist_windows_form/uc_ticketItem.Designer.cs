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
            this.pnlCheck = new System.Windows.Forms.Panel();
            this.txbTicketSubject = new System.Windows.Forms.TextBox();
            this.btnDetail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlCheck
            // 
            this.pnlCheck.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlCheck.Location = new System.Drawing.Point(17, 13);
            this.pnlCheck.Name = "pnlCheck";
            this.pnlCheck.Size = new System.Drawing.Size(71, 72);
            this.pnlCheck.TabIndex = 0;
            this.pnlCheck.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCheck_Paint);
            this.pnlCheck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCheck_MouseDown);
            // 
            // txbTicketSubject
            // 
            this.txbTicketSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTicketSubject.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txbTicketSubject.Location = new System.Drawing.Point(94, 24);
            this.txbTicketSubject.Name = "txbTicketSubject";
            this.txbTicketSubject.Size = new System.Drawing.Size(403, 39);
            this.txbTicketSubject.TabIndex = 1;
            this.txbTicketSubject.Enter += new System.EventHandler(this.txbTicketSubject_Enter);
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDetail.Location = new System.Drawing.Point(513, 13);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 72);
            this.btnDetail.TabIndex = 2;
            this.btnDetail.Text = "button1";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // uc_ticketItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.txbTicketSubject);
            this.Controls.Add(this.pnlCheck);
            this.Name = "uc_ticketItem";
            this.Size = new System.Drawing.Size(604, 101);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCheck;
        private System.Windows.Forms.TextBox txbTicketSubject;
        private System.Windows.Forms.Button btnDetail;
    }
}
