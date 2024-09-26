//*****************************************************************************
//** 729. My Calendar I   leetcode                                           **
//*****************************************************************************


// Define the Node structure
typedef struct Node {
    int start;
    int end;
    struct Node* left;
    struct Node* right;
} Node;

// Function to create a new Node
Node* createNode(int start, int end) {
    Node* node = (Node*)malloc(sizeof(Node));
    node->start = start;
    node->end = end;
    node->left = NULL;
    node->right = NULL;
    return node;
}

// Function to insert a node into the tree
bool insert(Node* root, Node* newNode) {
    if (newNode->start >= root->end) {
        if (root->right == NULL) {
            root->right = newNode;
            return true;
        }
        return insert(root->right, newNode);
    } else if (newNode->end <= root->start) {
        if (root->left == NULL) {
            root->left = newNode;
            return true;
        }
        return insert(root->left, newNode);
    } else {
        return false;  // Overlap found
    }
}

// Define the MyCalendar structure
typedef struct {
    Node* root;
} MyCalendar;

// Function to create a new MyCalendar
MyCalendar* myCalendarCreate() {
    MyCalendar* calendar = (MyCalendar*)malloc(sizeof(MyCalendar));
    calendar->root = NULL;
    return calendar;
}

// Function to book an interval in the calendar
bool myCalendarBook(MyCalendar* obj, int start, int end) {
    Node* newNode = createNode(start, end);
    if (obj->root == NULL) {
        obj->root = newNode;
        return true;
    }
    return insert(obj->root, newNode);
}

// Cleanup function to free memory
void freeNode(Node* node) {
    if (node == NULL) return;
    freeNode(node->left);
    freeNode(node->right);
    free(node);
}

// Free the calendar and its nodes
void myCalendarFree(MyCalendar* obj) {
    freeNode(obj->root);
    free(obj);
}

/**
 * Your MyCalendar struct will be instantiated and called as such:
 * MyCalendar* obj = myCalendarCreate();
 * bool param_1 = myCalendarBook(obj, start, end);
 
 * myCalendarFree(obj);
*/