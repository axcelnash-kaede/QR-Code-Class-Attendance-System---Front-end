window.showToast = function (message, type = "success") {
    const existing = document.querySelector(".custom-toast");

    if (existing) {
        existing.remove();
    }

    const toast = document.createElement("div");

    toast.className = "custom-toast";
    toast.innerText = message;

    const isError = type === "error";

    toast.style.position = "fixed";
    toast.style.top = "24px";
    toast.style.right = "24px";
    toast.style.zIndex = "999999";
    toast.style.minWidth = "280px";
    toast.style.maxWidth = "420px";
    toast.style.padding = "15px 18px";
    toast.style.borderRadius = "16px";
    toast.style.fontWeight = "700";
    toast.style.fontSize = "14px";
    toast.style.color = "#ffffff";
    toast.style.boxShadow = "0 14px 30px rgba(0,0,0,0.20)";
    toast.style.backdropFilter = "blur(8px)";
    toast.style.transition = "all .25s ease";
    toast.style.opacity = "0";
    toast.style.transform = "translateY(-14px)";

    if (isError) {
        toast.style.background = "linear-gradient(135deg, #dc2626, #ef4444)";
    } else {
        toast.style.background = "linear-gradient(135deg, #059669, #10b981)";
    }

    document.body.appendChild(toast);

    requestAnimationFrame(() => {
        toast.style.opacity = "1";
        toast.style.transform = "translateY(0)";
    });

    setTimeout(() => {
        toast.style.opacity = "0";
        toast.style.transform = "translateY(-14px)";

        setTimeout(() => {
            if (toast.parentNode) {
                toast.remove();
            }
        }, 250);
    }, 2600);
};

window.qrAttendancePrintPdf = function (data) {
    if (!window.jspdf || !window.jspdf.jsPDF) {
        alert("PDF library not loaded. Please refresh the page.");
        return;
    }

    const { jsPDF } = window.jspdf;
    const doc = new jsPDF("p", "mm", "a4");

    const pageWidth = 210;
    const margin = 15;
    let y = 18;

    const text = (value) => {
        if (value === null || value === undefined) return "";
        return String(value);
    };

    doc.setFont("helvetica", "bold");
    doc.setFontSize(18);
    doc.setTextColor(18, 59, 130);
    doc.text("QR Classroom Attendance Report", pageWidth / 2, y, {
        align: "center"
    });

    y += 8;

    doc.setFontSize(10);
    doc.setTextColor(15, 23, 42);
    doc.text(text(data.title), pageWidth / 2, y, {
        align: "center"
    });

    y += 6;

    doc.setFont("helvetica", "normal");
    doc.setFontSize(10);
    doc.text(
        `Session ID: ${text(data.sessionId)} | Generated: ${text(data.printedAt)}`,
        pageWidth / 2,
        y,
        { align: "center" }
    );

    y += 14;

    const boxes = [
        ["Total", data.totalStudents],
        ["Present", data.presentCount],
        ["Late", data.lateCount],
        ["Absent", data.absentCount],
        ["Excused", data.excusedCount]
    ];

    const boxWidth = 34;
    const boxHeight = 18;
    const gap = 4;
    const startX = (pageWidth - ((boxWidth * 5) + (gap * 4))) / 2;

    boxes.forEach((box, index) => {
        const x = startX + index * (boxWidth + gap);

        doc.setDrawColor(219, 234, 254);
        doc.setFillColor(248, 251, 255);
        doc.roundedRect(x, y, boxWidth, boxHeight, 3, 3, "FD");

        doc.setFont("helvetica", "bold");
        doc.setFontSize(12);
        doc.setTextColor(29, 78, 216);
        doc.text(String(box[1]), x + boxWidth / 2, y + 7, {
            align: "center"
        });

        doc.setFont("helvetica", "normal");
        doc.setFontSize(9);
        doc.setTextColor(15, 23, 42);
        doc.text(box[0], x + boxWidth / 2, y + 14, {
            align: "center"
        });
    });

    y += 30;

    const columns = [
        { title: "Student ID", width: 48 },
        { title: "Name", width: 65 },
        { title: "Status", width: 35 },
        { title: "Time", width: 30 }
    ];

    let x = margin;

    doc.setFillColor(234, 243, 255);
    doc.rect(margin, y, 180, 10, "F");

    doc.setFont("helvetica", "bold");
    doc.setFontSize(9);
    doc.setTextColor(18, 59, 130);

    columns.forEach(col => {
        doc.text(col.title, x + 2, y + 6.5);
        x += col.width;
    });

    y += 10;

    doc.setFont("helvetica", "normal");
    doc.setFontSize(9);
    doc.setTextColor(15, 23, 42);

    data.records.forEach(record => {
        if (y > 275) {
            doc.addPage();
            y = 18;
        }

        x = margin;

        const rowValues = [
            text(record.studentId),
            text(record.name),
            text(record.status),
            text(record.time)
        ];

        doc.setDrawColor(229, 231, 235);
        doc.line(margin, y + 9, 195, y + 9);

        rowValues.forEach((value, index) => {
            if (index === 2) {
                const status = value.toLowerCase();

                doc.setFont("helvetica", "bold");

                if (status === "present") doc.setTextColor(22, 101, 52);
                else if (status === "late") doc.setTextColor(154, 52, 18);
                else if (status === "absent") doc.setTextColor(153, 27, 27);
                else if (status === "excused") doc.setTextColor(29, 78, 216);
                else doc.setTextColor(15, 23, 42);
            } else {
                doc.setFont("helvetica", "normal");
                doc.setTextColor(15, 23, 42);
            }

            doc.text(value, x + 2, y + 6);
            x += columns[index].width;
        });

        y += 10;
    });

    y += 12;

    doc.setFont("helvetica", "normal");
    doc.setFontSize(9);
    doc.setTextColor(100, 116, 139);
    doc.text("Generated by QR Classroom Attendance System", pageWidth / 2, y, {
        align: "center"
    });

    doc.save(`Attendance_Report_${text(data.sessionId)}.pdf`);
};
