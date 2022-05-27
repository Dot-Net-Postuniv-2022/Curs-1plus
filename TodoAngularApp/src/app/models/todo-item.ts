export interface TodoItem {
    id?: number;
    name?: string;
    description?: string;
    isComplete?: boolean;

    preparingDelete?: boolean;
    isEditing?: boolean;
}
