﻿using System;
using System.Text;

namespace RocksDbSharp
{
    /*
    These wrappers provide translation from the error output of the C API into exceptions
    */
    public static partial class Native
    {
        public static IntPtr rocksdb_open(
            /* const rocksdb_options_t* */ IntPtr options,
            string name)
        {
            IntPtr errptr;
            var result = rocksdb_open(options, name, out errptr);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
            return result;
        }

        public static void rocksdb_put(
            /*rocksdb_t**/ IntPtr db,
            /*const rocksdb_writeoptions_t**/ IntPtr writeOptions,
            string key,
            string val,
            Encoding encoding = null)
        {
            IntPtr errptr;
            rocksdb_put(db, writeOptions, key, val, out errptr, encoding);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
        }

        public static void rocksdb_put(
            IntPtr db,
            IntPtr writeOptions,
            byte[] key,
            long keyLength,
            byte[] value,
            long valueLength)
        {
            IntPtr errptr;
            rocksdb_put(db, writeOptions, key, keyLength, value, valueLength, out errptr);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
        }


        public static string rocksdb_get(
            /*rocksdb_t**/ IntPtr db,
            /*const rocksdb_readoptions_t**/ IntPtr read_options,
            string key,
            Encoding encoding = null)
        {
            IntPtr errptr;
            var result = rocksdb_get(db, read_options, key, out errptr, encoding);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
            return result;
        }

        public static IntPtr rocksdb_get(
            IntPtr db,
            IntPtr read_options,
            byte[] key,
            long keyLength,
            out long vallen)
        {
            IntPtr errptr;
            var result = rocksdb_get(db, read_options, key, keyLength, out vallen, out errptr);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
            return result;
        }

        public static byte[] rocksdb_get(
            IntPtr db,
            IntPtr read_options,
            byte[] key,
            long keyLength)
        {
            IntPtr errptr;
            var result = rocksdb_get(db, read_options, key, keyLength, out errptr);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
            return result;
        }

        public static void rocksdb_delete(
            /*rocksdb_t**/ IntPtr db,
            /*const rocksdb_writeoptions_t**/ IntPtr writeOptions,
            /*const*/ string key)
        {
            IntPtr errptr;
            rocksdb_delete(db, writeOptions, key, out errptr);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
        }

        public static void rocksdb_delete(
            /*rocksdb_t**/ IntPtr db,
            /*const rocksdb_writeoptions_t**/ IntPtr writeOptions,
            /*const*/ byte[] key,
            long keylen)
        {
            IntPtr errptr;
            rocksdb_delete(db, writeOptions, key, keylen, out errptr);
            if (errptr != IntPtr.Zero)
                throw new RocksDbException(errptr);
        }

    }
}