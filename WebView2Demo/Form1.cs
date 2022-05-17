using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebView2Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Resize += new EventHandler(Form_Resize);
            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            Initialize();
        }
        /// <summary>
        /// 实现自适应页面缩放
        /// </summary>
        private void Form_Resize(object sender, EventArgs e)
        {
            webView21.Size = ClientSize - new Size(webView21.Location);
        }
        /// <summary>
        /// webview 加载完毕
        /// </summary>
        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.CoreWebView2.Navigate("https://www.baidu.com/");
        }
        /// <summary>
        /// WebView2初始化
        /// </summary>
        async void Initialize()
        {
            var result = await CoreWebView2Environment.CreateAsync(null, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache"), null);
            await webView21.EnsureCoreWebView2Async(result);
        }

        /// <summary>
        /// 点击按钮
        /// </summary>
        private async void button1_Click(object sender, EventArgs e)
        {
            //开启开发者工具 (可以通过右键，检查页面实现打开开发者工具)
            // webView21.CoreWebView2.OpenDevToolsWindow();

            //填充搜索内容
            await webView21.CoreWebView2.ExecuteScriptAsync("document.querySelector('#kw').value='1234'");
            //启动搜索
            await webView21.CoreWebView2.ExecuteScriptAsync("document.querySelector('#su').click();");
        }
    }
}
