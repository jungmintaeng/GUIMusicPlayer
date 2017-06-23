namespace GUIMusicPlayer
{
    partial class mainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.prevButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.playOrderButton = new System.Windows.Forms.Button();
            this.musicList = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderAddButton = new System.Windows.Forms.Button();
            this.fileAddButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.currentPositionLabel = new System.Windows.Forms.Label();
            this.maxPositionLabel = new System.Windows.Forms.Label();
            this.musicProgressbar = new System.Windows.Forms.TrackBar();
            this.playRepeatButton = new System.Windows.Forms.Button();
            this.musiclistHideButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.musicProgressbar)).BeginInit();
            this.SuspendLayout();
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fileNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(305, 29);
            this.fileNameTextBox.TabIndex = 0;
            // 
            // prevButton
            // 
            this.prevButton.Location = new System.Drawing.Point(12, 113);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(97, 39);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "이전 곡";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(115, 113);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(99, 39);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "재생";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(220, 113);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(97, 39);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "다음 곡";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // playOrderButton
            // 
            this.playOrderButton.Location = new System.Drawing.Point(12, 158);
            this.playOrderButton.Name = "playOrderButton";
            this.playOrderButton.Size = new System.Drawing.Size(97, 39);
            this.playOrderButton.TabIndex = 4;
            this.playOrderButton.Text = "순차 재생";
            this.playOrderButton.UseVisualStyleBackColor = true;
            this.playOrderButton.Click += new System.EventHandler(this.playOrderButton_Click);
            // 
            // musicList
            // 
            this.musicList.AllowDrop = true;
            this.musicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.duration});
            this.musicList.Location = new System.Drawing.Point(12, 203);
            this.musicList.Name = "musicList";
            this.musicList.Size = new System.Drawing.Size(305, 359);
            this.musicList.TabIndex = 5;
            this.musicList.UseCompatibleStateImageBehavior = false;
            this.musicList.View = System.Windows.Forms.View.Details;
            this.musicList.DragDrop += new System.Windows.Forms.DragEventHandler(this.musicList_DragDrop);
            this.musicList.DragEnter += new System.Windows.Forms.DragEventHandler(this.musicList_DragEnter);
            this.musicList.DoubleClick += new System.EventHandler(this.musicList_DoubleClick);
            this.musicList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.musicList_KeyDown);
            // 
            // fileName
            // 
            this.fileName.Text = "파일명";
            this.fileName.Width = 240;
            // 
            // duration
            // 
            this.duration.Text = "시간";
            // 
            // folderAddButton
            // 
            this.folderAddButton.Location = new System.Drawing.Point(115, 568);
            this.folderAddButton.Name = "folderAddButton";
            this.folderAddButton.Size = new System.Drawing.Size(99, 39);
            this.folderAddButton.TabIndex = 7;
            this.folderAddButton.Text = "폴더 추가";
            this.folderAddButton.UseVisualStyleBackColor = true;
            this.folderAddButton.Click += new System.EventHandler(this.folderAddButton_Click);
            // 
            // fileAddButton
            // 
            this.fileAddButton.Location = new System.Drawing.Point(12, 568);
            this.fileAddButton.Name = "fileAddButton";
            this.fileAddButton.Size = new System.Drawing.Size(97, 39);
            this.fileAddButton.TabIndex = 8;
            this.fileAddButton.Text = "파일 추가";
            this.fileAddButton.UseVisualStyleBackColor = true;
            this.fileAddButton.Click += new System.EventHandler(this.fileAddButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(220, 568);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(97, 39);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "제거";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // currentPositionLabel
            // 
            this.currentPositionLabel.AutoSize = true;
            this.currentPositionLabel.Location = new System.Drawing.Point(12, 47);
            this.currentPositionLabel.Name = "currentPositionLabel";
            this.currentPositionLabel.Size = new System.Drawing.Size(33, 12);
            this.currentPositionLabel.TabIndex = 11;
            this.currentPositionLabel.Text = "00:00";
            // 
            // maxPositionLabel
            // 
            this.maxPositionLabel.AutoSize = true;
            this.maxPositionLabel.Location = new System.Drawing.Point(284, 47);
            this.maxPositionLabel.Name = "maxPositionLabel";
            this.maxPositionLabel.Size = new System.Drawing.Size(33, 12);
            this.maxPositionLabel.TabIndex = 12;
            this.maxPositionLabel.Text = "00:00";
            // 
            // musicProgressbar
            // 
            this.musicProgressbar.Location = new System.Drawing.Point(14, 62);
            this.musicProgressbar.Name = "musicProgressbar";
            this.musicProgressbar.Size = new System.Drawing.Size(303, 45);
            this.musicProgressbar.TabIndex = 13;
            this.musicProgressbar.Scroll += new System.EventHandler(this.musicProgressbar_Scroll);
            // 
            // playRepeatButton
            // 
            this.playRepeatButton.Location = new System.Drawing.Point(115, 158);
            this.playRepeatButton.Name = "playRepeatButton";
            this.playRepeatButton.Size = new System.Drawing.Size(99, 39);
            this.playRepeatButton.TabIndex = 14;
            this.playRepeatButton.Text = "반복 없음";
            this.playRepeatButton.UseVisualStyleBackColor = true;
            this.playRepeatButton.Click += new System.EventHandler(this.playRepeatButton_Click);
            // 
            // musiclistHideButton
            // 
            this.musiclistHideButton.Location = new System.Drawing.Point(220, 158);
            this.musiclistHideButton.Name = "musiclistHideButton";
            this.musiclistHideButton.Size = new System.Drawing.Size(97, 39);
            this.musiclistHideButton.TabIndex = 4;
            this.musiclistHideButton.Text = "재생목록 닫기";
            this.musiclistHideButton.UseVisualStyleBackColor = true;
            this.musiclistHideButton.Click += new System.EventHandler(this.musiclistHideButton_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 614);
            this.Controls.Add(this.playRepeatButton);
            this.Controls.Add(this.musicProgressbar);
            this.Controls.Add(this.maxPositionLabel);
            this.Controls.Add(this.currentPositionLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.fileAddButton);
            this.Controls.Add(this.folderAddButton);
            this.Controls.Add(this.musicList);
            this.Controls.Add(this.musiclistHideButton);
            this.Controls.Add(this.playOrderButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.fileNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.musicProgressbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button playOrderButton;
        private System.Windows.Forms.ListView musicList;
        private System.Windows.Forms.Button folderAddButton;
        private System.Windows.Forms.Button fileAddButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader duration;
        private System.Windows.Forms.Label currentPositionLabel;
        private System.Windows.Forms.Label maxPositionLabel;
        private System.Windows.Forms.TrackBar musicProgressbar;
        private System.Windows.Forms.Button playRepeatButton;
        private System.Windows.Forms.Button musiclistHideButton;
    }
}

