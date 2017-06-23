using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace GUIMusicPlayer
{
    public partial class mainForm : Form
    {
        private WindowsMediaPlayer playerInstance;
        private IWMPPlaylist playList;
        private List<IWMPMedia> playListManager;
        private Thread progressThread;
        private bool isPlaying = false;
        private IWMPMedia latestMedia;
        private Boolean ended = false;

        public mainForm()
        {
            InitializeComponent();
        }

        //폼이 로드될 때
        private void mainForm_Load(object sender, EventArgs e)
        {
            playerInstance = new WindowsMediaPlayer();
            playList = playerInstance.newPlaylist("MusicPlayer", "");
            playerInstance.currentPlaylist = playList;
            playListManager = new List<IWMPMedia>();
            progressThread = new Thread(new ThreadStart(Progress));
            progressThread.Start();
            playerInstance.PlayStateChange += PlayerInstance_PlayStateChange;
        }

        /*
         * filePath를 통해 해당 Path에 존재하는 파일을 재생목록에 추가하는 메소드
         */
        private void addFile(string filePath)
        {
            if (!Path.GetExtension(filePath).Equals(".mp3"))
            {
                MessageBox.Show(Path.GetFileName(filePath) + "는 mp3 파일이 아닙니다.");
                return;
            }

            //WMP 재생목록에 추가
            IWMPMedia newMedia = playerInstance.newMedia(filePath);
            playList.appendItem(newMedia);

            //미디어 리스트에 추가
            playListManager.Add(newMedia);

            //ListView에 추가
            ListViewItem newItem = new ListViewItem(Path.GetFileName(filePath));
            newItem.SubItems.Add(parseToMinuteString(newMedia.duration));
            musicList.Items.Add(newItem);
        }

        /*
         * 분이나 초가 한 자리수이면 앞에 0을 붙여주는 메소드
         */
        private string leadingZero(string number)
        {
            if (number.Length < 2)
            {
                number = "0" + number;
            }
            return number;
        }

        /*
         * double 형의 노래 지속 시간을 분 형태로 바꿔서 string으로 반환하는 메소드
         */
        private string parseToMinuteString(double duration)
        {
            string min = ((int)duration / 60).ToString();
            string sec = ((int)duration % 60).ToString();
            return leadingZero(min) + ":" + leadingZero(sec);
        }

        /*
         * 현재 재생 중인 곡을 삭제 하는 등의 행동을 했을 때, 재생 버튼의 텍스트나
         * 재생 중인 파일 명, ProgressBar value 등을 초기로 돌림
         */
        private void initState()
        {
            try
            {
                isPlaying = false;
                fileNameTextBox.Text = "";
                playButton.Text = "재생";
                musicProgressbar.Value = 0;
                musicProgressbar.Maximum = 0;
                maxPositionLabel.Text = "00:00";
                currentPositionLabel.Text = "00:00";
            }
            catch (ObjectDisposedException) { }
        }

        /*
         * ProgressBar가 실행할 메소드
         */
        private void Progress()
        {
            while (true)
            {
                try
                {
                    Invoke(new MethodInvoker(() =>
                {
                    try
                    {
                        currentPositionLabel.Text = parseToMinuteString(playerInstance.controls.currentPosition);
                        maxPositionLabel.Text = parseToMinuteString(playerInstance.currentMedia.duration);
                        musicProgressbar.Maximum = (int)playerInstance.currentMedia.duration;
                        musicProgressbar.Value = (int)playerInstance.controls.currentPosition;
                        fileNameTextBox.Text = playerInstance.currentMedia.name;
                    }
                    catch (Exception)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            initState();
                        }));
                    }
                }));
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        //재생 버튼 클릭 이벤트
        private void playButton_Click(object sender, EventArgs e)
        {
            if(playList.count < 1)
            {
                MessageBox.Show("재생 목록에 곡을 추가해주세요.");
                return;
            }
            if (isPlaying)
            {
                playerInstance.controls.pause();
                playButton.Text = "재생";
                isPlaying = false;
            }
            else
            {
                ended = false;
                playerInstance.controls.play();
                playButton.Text = "일시 정지";
                isPlaying = true;
            }
        }

        //이전 곡 버튼 클릭 이벤트
        private void prevButton_Click(object sender, EventArgs e)
        {
            if(playerInstance.controls.currentPosition > 5)
            {
                playerInstance.controls.currentPosition = 0;
            }
            else
            {
                ended = false;
                playerInstance.controls.previous();
                latestMedia = playerInstance.currentMedia;
            }
        }

        //다음 곡 버튼 클릭 이벤트
        private void nextButton_Click(object sender, EventArgs e)
        {
            ended = false;
            playerInstance.controls.next();
            latestMedia = playerInstance.currentMedia;
        }

        //파일 추가 버튼 클릭 이벤트
        private void fileAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MP3 File(*.mp3)|*.mp3";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                addFile(dialog.FileName);
            }
        }

        //폴더 추가 버튼 클릭 이벤트
        private void folderAddButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo selectedPathInfo = new DirectoryInfo(dialog.SelectedPath);
                foreach(var file in selectedPathInfo.GetFiles())
                {
                    if (!file.Extension.Equals(".mp3"))
                    {
                        continue;
                    }
                    addFile(file.FullName);
                }
            }
        }

        //재생 목록에서 제거 버튼 클릭 이벤트
        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach(var music in musicList.SelectedItems)
            {
                int removeIndex = musicList.Items.IndexOf((ListViewItem)music);
                if (playerInstance.currentMedia.sourceURL.Equals(playListManager[removeIndex].sourceURL))
                    initState();
                musicList.Items.RemoveAt(removeIndex);
                playList.removeItem(playListManager[removeIndex]);
                playListManager.RemoveAt(removeIndex);
            }
        }

        //트랙바 스크롤 시
        private void musicProgressbar_Scroll(object sender, EventArgs e)
        {
            try
            {
                playerInstance.controls.currentPosition = musicProgressbar.Value;
            }
            catch (Exception) { }
        }
        
        //폼 꺼질 때(리소스 해제)
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                playerInstance.close();
            }
            catch (Exception) { }
            try
            {
                progressThread.Abort();
            }
            catch (Exception) { }
        }

        //재생목록 열기 닫기 버튼 클릭 이벤트
        private void musiclistHideButton_Click(object sender, EventArgs e)
        {
            if (musiclistHideButton.Text.Equals("재생목록 열기"))
            {
                musiclistHideButton.Text = "재생목록 닫기";
                this.Size = new Size(345, 653);
            }
            else if (musiclistHideButton.Text.Equals("재생목록 닫기"))
            {
                musiclistHideButton.Text = "재생목록 열기";
                this.Size = new Size(345, 241);
            }
        }

        //재생 순서 버튼 클릭 이벤트
        private void playOrderButton_Click(object sender, EventArgs e)
        {
            if (playOrderButton.Text.Equals("순차 재생"))
            {
                playOrderButton.Text = "랜덤 재생";
                playerInstance.settings.setMode("shuffle", true);
            }
            else if (playOrderButton.Text.Equals("랜덤 재생"))
            {
                playOrderButton.Text = "순차 재생";
                playerInstance.settings.setMode("shuffle", false);
            }
        }
        
        //재생 반복 버튼 클릭 이벤트
        private void playRepeatButton_Click(object sender, EventArgs e)
        {
            if (playRepeatButton.Text.Equals("전곡 반복"))
            {
                playRepeatButton.Text = "반복 없음";
                playerInstance.settings.setMode("loop", false);
            }
            else if (playRepeatButton.Text.Equals("반복 없음"))
            {
                playRepeatButton.Text = "한곡 반복";
                playerInstance.settings.setMode("loop", true);
                ended = false;
                latestMedia = playerInstance.currentMedia;
            }
            else if (playRepeatButton.Text.Equals("한곡 반복"))
            {
                playRepeatButton.Text = "전곡 반복";
            }
        }

        //뮤직 플레이어 상태 바뀌었을 때 --> 한곡반복, 전체 반복 등 처리
        private void PlayerInstance_PlayStateChange(int NewState)
        {
            if (playRepeatButton.Text.Equals("한곡 반복") && NewState == 3)
            {
                if (ended)
                {
                    ended = false;
                    playerInstance.controls.playItem(latestMedia);
                }
                else
                    ended = true;
            }
        }

        // 파일&폴더 드래그앤드랍
        private void musicList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void musicList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in files)
            {
                if (Path.GetExtension(filePath).Equals(".mp3"))
                    addFile(filePath);

                DirectoryInfo dir = new DirectoryInfo(filePath);
                if (dir.Attributes.ToString().Equals("Directory"))
                {
                    foreach (var file in dir.GetFiles())
                    {
                        if (!file.Extension.Equals(".mp3"))
                        {
                            continue;
                        }
                        addFile(file.FullName);
                    }
                }
            }
        }

        // 키보드 delete 버튼으로 음악 삭제 추가
        private void musicList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                removeButton.PerformClick();
        }

        // 마우스 더블클릭으로 음악 재생 추가
        private void musicList_DoubleClick(object sender, EventArgs e)
        {
            int idx = musicList.Items.IndexOf((ListViewItem)musicList.SelectedItems[0]);
            while (true)
            {
                try
                {
                    playerInstance.controls.playItem(playListManager[idx]);
                    break;
                }
                catch (Exception)
                {
                    playerInstance.controls.next();
                }
            }
        }
    }
}
