const CART_KEY = "furni_cart_v1";
const LEGACY_KEY = "cart";

export function getCart() {
    try {
        const raw = localStorage.getItem(CART_KEY) ?? localStorage.getItem(LEGACY_KEY);
        return raw ? JSON.parse(raw) : [];
    } catch {
        return [];
    }
}

export function saveCart(items) {
    const raw = JSON.stringify(items);
    // write both current and legacy keys so old pages/scripts still work
    localStorage.setItem(CART_KEY, raw);
    localStorage.setItem(LEGACY_KEY, raw);
}

export function addToCart(productId, qty = 1) {
    const id = Number(productId);
    const q = Number(qty);

    if (!Number.isFinite(id) || id <= 0) throw new Error("Invalid productId");
    if (!Number.isFinite(q) || q <= 0) throw new Error("Invalid quantity");

    const cart = getCart();
    const existing = cart.find(i => i.productId === id);

    if (existing) existing.quantity += q;
    else cart.push({ productId: id, quantity: q });

    saveCart(cart);
    return cart;
}

export function setQty(productId, qty) {
    const id = Number(productId);
    const q = Number(qty);

    const cart = getCart()
        .map(i => (i.productId === id ? { ...i, quantity: q } : i))
        .filter(i => Number(i.quantity) > 0);

    saveCart(cart);
    return cart;
}

export function removeItem(productId) {
    const id = Number(productId);
    const cart = getCart().filter(i => i.productId !== id);
    saveCart(cart);
    return cart;
}

export function clearCart() {
    saveCart([]);
}

export function cartCount() {
    return getCart().reduce((sum, i) => sum + Number(i.quantity || 0), 0);
}