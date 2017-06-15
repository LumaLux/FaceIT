#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Wed Jun 14 09:23:32 2017

@author: joey
"""

import pymysql
import pymysql.cursors


connection = pymysql.connect(host='localhost', 
                             user='root', 
                             password='', 
                             db='FaceIT', 
                             charset='utf8mb4', 
                             cursorclass=pymysql.cursors.DictCursor)
def dbClose():
    connection.close()

def newStudent(klas, periode, folder):
    try:
        with connection.cursor() as cursor:
            sql = "INSERT INTO `leerling` (`Aanwezig`, `Klas_KlasNaam`, `Klas_Periode`, `Folder`) VALUES (%s, %s, %s, %s)"
            cursor.execute(sql, ("1", klas, periode, folder))
        connection.commit()
    except Exception as e:
        print('Got error {!r}, errno is {}'.format(e, e.args[0]))

def AddPresence(folder, klas, periode):
    try:
        with connection.cursor() as cursor:
            sql = "UPDATE `leerling` SET `Aanwezig` = `Aanwezig` + 1 WHERE Folder = %s AND Klas_KlasNaam = %s AND Klas_Periode = %s"
            cursor.execute(sql, (folder, klas, periode))
        connection.commit()
    except Exception as e:
        print('Got error {!r}, errno is {}'.format(e, e.args[0]))