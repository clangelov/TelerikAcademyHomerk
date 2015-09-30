<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/studetns">    
    <html>
      <style>
        table {
          font-size: 20px;
          text-align: center;
          border-collapse: collapse;
        }

        table, th, td {
          border: 2px solid black;
        } 
        
        th, td {
          padding: 15px;
        }
      </style>
      
      <body>
        <h3>A sample tabel of students</h3>
        <table>
          <tr>
            <th>Student</th>
            <th>Gender</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>E-mail</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty #</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="student">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="gender" />
              </td>
              <td>
                <xsl:value-of select="birthdate" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="speciality" />
              </td>
              <td>
                <xsl:value-of select="facultynumber" />
              </td>
              <td>
                <xsl:for-each select="exams">
                  <div>
                    <strong>
                      <xsl:value-of select="exam/name"/>
                    </strong> -
                    tutor: <xsl:value-of select="exam/tutor"/> -
                    score: <xsl:value-of select="exam/score"/>
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
