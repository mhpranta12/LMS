import React, { useEffect, useState } from "react";
import { Table, Card, Typography, Tag, message } from "antd";
import type { ColumnsType } from "antd/es/table";
import axios from "axios";

const { Title } = Typography;

interface Book {
    id: string;
    title: string;
    publisher?: string;
    branch?: string;
    category?: string;
    isBorrowed: boolean;
}

interface ApiResponse<T> {
    isSuccess: boolean;
    message: string;
    result: T;
}

const BookList: React.FC = () => {
    const [books, setBooks] = useState<Book[]>([]);
    const [loading, setLoading] = useState(false);

    const loadBooks = async () => {
        try {
            setLoading(true);

            const response = await axios.get<ApiResponse<Book[]>>(
                "https://localhost:7063/api/Book/GetAll"
            );

          if (response.data.isSuccess) {
              setBooks(response.data.result);
          } else {
              message.error(response.data.message);
          }
        } catch (error) {
            message.error("Failed to load books.");
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        loadBooks();
    }, []);

    const columns: ColumnsType<Book> = [
        {
            title: "Title",
            dataIndex: "title",
            key: "title",
        },
        {
            title: "Publisher",
            dataIndex: "publisher",
            key: "publisher",
        },
        {
            title: "Branch",
            dataIndex: "branch",
            key: "branch",
        },
        {
            title: "Category",
            dataIndex: "category",
            key: "category",
        },
        {
            title: "Status",
            dataIndex: "isBorrowed",
            key: "isBorrowed",
            render: (value: boolean) =>
                value ? (
                    <Tag color="red">Borrowed</Tag>
                ) : (
                    <Tag color="green">Available</Tag>
                ),
        },
    ];

    return (
        <Card>
            <Title level={3}>Book List</Title>

            <Table<Book>
                rowKey="id"
                loading={loading}
                columns={columns}
                dataSource={books}
                bordered
                pagination={{
                    pageSize: 10,
                    showSizeChanger: true,
                }}
            />
        </Card>
    );
};

export default BookList;
