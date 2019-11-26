using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyApp.Tool
{
    public class NetBufferWriter
    {
        MemoryStream m_stream = null;
        BinaryWriter m_writer = null;

        int m_finishLength;

        public int finishLength
        {
            get { return m_finishLength; }
        }

        public NetBufferWriter()
        {
            m_finishLength = 0;
            m_stream = new MemoryStream();
            m_writer = new BinaryWriter(m_stream);
        }

        public void WriteByte(byte v)
        {
            m_writer.Write(v);
        }

        public void WriteInt(int v)
        {
            m_writer.Write(v);
        }

        public void WriteUInt(uint v)
        {
            m_writer.Write(v);
        }

        public void WriteShort(short v)
        {
            m_writer.Write(v);
        }

        public void WriteUShort(ushort v)
        {
            m_writer.Write(v);
        }

        public void WriteLong(long v)
        {
            m_writer.Write(v);
        }

        public void WriteULong(ulong v)
        {
            m_writer.Write(v);
        }

        public void WriteFloat(float v)
        {
            m_writer.Write(v);
        }

        public void WriteDouble(double v)
        {
            m_writer.Write(v);
        }

        public void WriteString(string v)
        {
            m_writer.Write(v);
        }

        public void WriteBytes(byte[] v)
        {
            m_writer.Write(v.Length);
            m_writer.Write(v);
        }

        public byte[] ToBytes()
        {
            m_writer.Flush();
            return m_stream.ToArray();
        }

        public void Close()
        {
            if (m_writer != null)
            {
                m_writer.Close();
            }

            if (m_stream != null)
            {
                m_stream.Close();
            }
            m_writer = null;
            m_stream = null;
        }

        public byte[] Finish()
        {
            byte[] message = ToBytes();
            MemoryStream ms = new MemoryStream();
            ms.Position = 0;
            BinaryWriter writer = new BinaryWriter(ms);
            writer.Write((ushort)message.Length);
            writer.Write(message);
            writer.Flush();

            byte[] result = ms.ToArray();
            m_finishLength = result.Length;
            return result;

        }

    }
}
