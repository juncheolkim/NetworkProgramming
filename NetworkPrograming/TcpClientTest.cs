﻿using System.Net.Sockets;
using System.Text;

namespace NetworkProgramming
{
    internal class TcpClientTest
    {
        static void Main(string[] args)
        {
            // (1) IP 주소와 포트를 지정하고 TCP 연결 
            System.Net.Sockets.TcpClient tc = new System.Net.Sockets.TcpClient("127.0.0.1", 7000);
            //TcpClient tc = new TcpClient("localhost", 7000);

            string msg = "Hello World";
            byte[] buff = Encoding.ASCII.GetBytes(msg);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);

            // (4) 스트림으로부터 바이트 데이타 읽기
            byte[] outbuf = new byte[1024];
            int nbytes = stream.Read(outbuf, 0, outbuf.Length);
            string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);

            // (5) 스트림과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();

            Console.WriteLine($"{nbytes} bytes: {output}");
        }
    }
}
